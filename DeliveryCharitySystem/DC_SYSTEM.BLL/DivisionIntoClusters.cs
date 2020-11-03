using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Accord.MachineLearning;
using DC_SYSTEM._BE;
using DC_SYSTEM.DAL;

namespace DC_SYSTEM.BLL
{
	//Class to Divide the addresses into clusters
    public class DivisionIntoClusters
    {
		//The function create deliveries according list of adults, deliverMans and Date, calculat Clusters and return array of them.
		public Delivery[] DivisionToClusters(List<Adult> adults,List<DeliveryMan> deliveryMen, int K , DateTime DDate)
		{
			if (K != 0)
			{
				int[] labels = calculatClusters(adressListToCordinate(AddressOfAdult(adults)), K);
				int count = 0;
				Delivery[] deliveries = new Delivery[labels.Length];
				foreach (var adult in adults)
				{

					deliveries[count] = new Delivery(DDate, adult, deliveryMen[labels[count]], labels[count], false);
					new DAL_IMP().Add_Delivery(deliveries[count]);
					count++;
				}
				return deliveries;
			}
			return null;
		}
		//the function return List Of Delivery from deliveries array in speific AreaGroup(K)

		public List<Delivery> DivisionToDelivery(Delivery[] deliveries, int K)
		{
			List<Delivery> deliveryList = new List<Delivery> ();
			for (int i = 0; i < deliveries.Length; i++)
				if (deliveries[i].AreaGroup == K)
						deliveryList.Add(deliveries[i]);
			return deliveryList;

		}
		//The function returns a List of addresses of adults
		public List<Address> AddressOfAdult(List<Adult> adults)
		{
			List<Address> addressList = new List<Address>();
			foreach (Adult adult in adults)
			{
				addressList.Add(new Address(adult.Address.Street, adult.Address.BuildingNumber, adult.Address.City));
			}
			return addressList;

		}
		//The funtion converts Addresss list to matrix of cordinates
		public double[][] adressListToCordinate(List<Address> addressList)
		{
			List<double[]> corArray = new List<double[]>();
			foreach (var a in addressList)
			{
				corArray.Add(adressToCordinate(a));
			}
			return corArray.ToArray();
		}
		//The function convert address to cordinate
		public double[] adressToCordinate(Address address)
		{
			return new AddressVertification().GetLatLongFromAddress(address);
		}
		//The function recive matrix of cordinate and K and calculatClusters
		public int[] calculatClusters(double[][] AdultsList, int K)
		{
		
				Accord.Math.Random.Generator.Seed = 0;

				// A common desire when doing clustering is to attempt to find how to 
				// weight the different components / columns of a dataset, giving them 
				// different importances depending on the end goal of the clustering task.

				// Declare some observations
				double[][] observations = AdultsList;

				// Create a new K-Means algorithm
				KMeans kmeans = new KMeans(k: K)
				{
					// For example, let's say we would like to consider the importance of 
					// the first column as 0.1, the second column as 0.7 and the third 0.9
					//Distance = new WeightedSquareEuclidean(new double[] { 0.1, 0.7, 1.1 })
				};

				// Compute and retrieve the data centroids
				var clusters = kmeans.Learn(observations);

				// Use the centroids to parition all the data
				int[] labels = clusters.Decide(observations);
				return labels;
			
		}
	}
}
