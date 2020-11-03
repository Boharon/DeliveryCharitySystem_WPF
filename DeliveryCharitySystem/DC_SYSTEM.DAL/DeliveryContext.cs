using DC_SYSTEM._BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DC_SYSTEM.DAL

{
    public class DeliveryContext : DbContext
    {
        
        public DeliveryContext() : base("Delivery_System_DB")
        {
           
        }
    
    
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryMan> DeliveryMans { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Address> Addresses { get; set; }
   
        
    }
}
