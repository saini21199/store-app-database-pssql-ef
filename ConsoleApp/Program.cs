using ConsoleApp.QueryingDatabase;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        private static DepartmentContext context = new DepartmentContext();
        
        static void Main(string[] args)
        {
            //AddInventoryTable();
            QueryingStore querystore = new QueryingStore();
            //querystore.queryStaff(context);
            //querystore.queryProduct(context);
            //querystore.queryCategory(context);
            //querystore.querySupplier(context);
            querystore.queryProductAndSupplier(context);
        }

        private static void AddInventoryTable() {
            var invetory = new Inventory { 
                product_id= 5,
                quantity=456
            };

            context.inventory.Add(invetory);
            context.SaveChanges();
        }
        private static void AddPurchaseOrder()
        {
            DateTime dateordered = new DateTime(2021, 05, 15);
            var order = new PurchaseOrder
            {
                order_id=4,
                supplier_id = 2,
                product_id = 6,
                supply_date = dateordered
            };
            context.porder.Add(order);
            context.SaveChanges();
        }
        private static void AddStaff()
        {
            var address = new Address
            {
                addressLine_1 = "RZ-321",
                city = "Gurgaon",
                state = "Haryana",
                pincode = 124567
            };

            var role = new Role
            {
                name = "Billing",
                description = "Generates Bills"
            };

            var staff = new Staff {
                Staff_name = "Ritu Bhatt",
                phone_no = "8731012568",
                addresses = address,
                roles =role
            };

            //context.address.Add(add)
            context.staff.Add(staff);
            context.SaveChanges();
        }

        private static void AddProduct() {
            //var category = new Category
            //{
            //    category_id =5,
            //    cat_name= "Snacks",
            //    cat_code = "SNAK"
            //};

            var product = new Product
            {
                name= "Maggie",
                manufacturer= "HUL",
                costPrice= 8,
                sellingPrice= 12,
                category_id=5
            };
            context.product.Add(product);
            context.SaveChanges();
        }

        private static void AddSupplier() {
            var supplier = new Supplier {
                sup_name= "Naresh Das",
                email= "ndas@gmail.com",
                phone_no= "9123345785",
                city= "Sonipat"
            };
            context.supplier.Add(supplier);
            context.SaveChanges();
        }
    }
}
