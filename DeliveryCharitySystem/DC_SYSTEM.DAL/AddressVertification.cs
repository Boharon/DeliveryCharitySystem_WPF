﻿using DC_SYSTEM._BE;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DC_SYSTEM.DAL
{
	public class AddressVertification
	{

        /// <summary>
        /// Receives an address and returns whether the address really exists
        /// </summary>
        /// <param name="address">The address to check</param>
        public bool IsRealAdrress(Address address)
        {
            JObject contentAsJSON = GetAdderssJson(address);
            string street = contentAsJSON["results"][0]["locations"][0]["street"].ToString();

            return street.Contains(address.Street);
        }
        //The function receives an address and returns its cordinates
        public double[] GetLatLongFromAddress(Address address)
        {
            JObject contentAsJSON = GetAdderssJson(address);
            double latitude = double.Parse(contentAsJSON["results"][0]["locations"][0]["latLng"]["lat"].ToString());
            double longitude = double.Parse(contentAsJSON["results"][0]["locations"][0]["latLng"]["lng"].ToString());
            return new double[] { latitude, longitude };
        }

        //The function receives an address from internet server and returns a Json object that represents the address cordinates .
        private JObject GetAdderssJson(Address address)
        {
            string location = address.ToString() + ", ישראל";
            string KEY = @"5rRMSAOyU11mGgkbAlWk3C1y1y0nT2Gv";

            var client = new RestClient("http://www.mapquestapi.com/geocoding/v1/address");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddParameter("key", KEY);
            request.AddParameter("location", location);
            request.AddParameter("maxResults", 1);
            request.AddParameter("thumbMaps", false);


            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            object deserializeContent = JsonConvert.DeserializeObject<object>(response.Content);
            return JObject.Parse(deserializeContent.ToString());
        }
    }
}

