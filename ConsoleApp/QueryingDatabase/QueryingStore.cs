using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.QueryingDatabase
{
    public class QueryingStore
    {
        public void queryStaff(DepartmentContext context) {

            // var result = context.staff.Where(s => s.Staff_name == "Raj Kumar").ToList();

            // var result = context.staff.Where(s => s.phone_no == "9771012568").ToList();

            // var result = context.staff.Where(s => s.role_id ==1).ToList();

            //foreach (Staff i in result) {
            //    Console.WriteLine("Staff_id : "+i.staff_id);
            //    Console.WriteLine("Staff_Name : "+ i.Staff_name);
            //    Console.WriteLine("Phone_no : "+i.phone_no);
            //    Console.WriteLine("Role_Id : "+i.role_id);
            //    Console.WriteLine("Address_Id : "+i.address_id);
            //}  

            var result = (from s in context.staff
                          join r in context.role
                          on s.role_id equals r.role_id
                          where s.Staff_name == "Raj Kumar"
                          select new
                          {
                              staff_id = s.staff_id,
                              staff_name = s.Staff_name,
                              role_id = r.role_id,
                              role_name = r.name
                          }).ToList();

            foreach (var i in result)
            {
                Console.WriteLine("Staff_id : " + i.staff_id);
                Console.WriteLine("Staff_Name : " + i.staff_name);
                Console.WriteLine("Role_Id : " + i.role_id);
                Console.WriteLine("Address_Id : " + i.role_name);
            }
        }

        public void queryProduct(DepartmentContext context) {

            //var result = context.product.Where(p=>p.name=="Maggie").ToList();

            //foreach (Product i in result) {
            //    Console.WriteLine("Product_id : " + i.product_id);
            //    Console.WriteLine("Product Name : " + i.name);
            //    Console.WriteLine("Product Manufacturer : " + i.manufacturer);
            //    Console.WriteLine("Cost Price : " + i.costPrice);
            //    Console.WriteLine("Selling Price : " + i.sellingPrice);
            //}

            //var result = (from p in context.product
            //              join c in context.category
            //              on p.category_id equals c.category_id
            //              where p.category_id ==2
            //              select new { 
            //                Product_Id =p.product_id,
            //                Product_Name = p.name,
            //                Product_Manufacturer = p.manufacturer,
            //                Category_Id = p.category_id,
            //                Category_Code = c.cat_code,
            //                Category_Name = c.cat_name
            //              }).ToList();


            //foreach (var i in result)
            //{
            //    Console.WriteLine("Product_Id : " + i.Product_Id);
            //    Console.WriteLine("Product_Name : " + i.Product_Name);
            //    Console.WriteLine("Product_Manufacturer : " + i.Product_Manufacturer);
            //    Console.WriteLine("Category_Id : " + i.Category_Id);
            //    Console.WriteLine("Category_Code : " + i.Category_Code);
            //    Console.WriteLine("Category_Name : " + i.Category_Name);
            //}

            //var result = (from p in context.product
            //              join i in context.inventory
            //              on p.category_id equals i.product_id
            //              where i.quantity > 300
            //              select new
            //              {
            //                  Product_Id = p.product_id,
            //                  Product_Name = p.name,
            //                  Product_Quantity = i.quantity,
            //              }).ToList();

            //foreach (var i in result) {
            //    Console.WriteLine("Product_Id : " + i.Product_Id);
            //    Console.WriteLine("Product_Name : " + i.Product_Name);
            //    Console.WriteLine("Product_Quantity : " + i.Product_Quantity);
            //}


            //var result = context.product.Where(p => p.sellingPrice > 250).ToList();

            //foreach(Product i in result)
            //{
            //    Console.WriteLine("Product_id : " + i.product_id);
            //    Console.WriteLine("Product Name : " + i.name);
            //    Console.WriteLine("Product Manufacturer : " + i.manufacturer);
            //    Console.WriteLine("Cost Price : " + i.costPrice);
            //    Console.WriteLine("Selling Price : " + i.sellingPrice);
            //}

            //var result = (from p in context.product
            //              join i in context.inventory
            //              on p.product_id equals i.product_id
            //              where i.quantity < 100
            //              select new { Product_Id = p.product_id }).Count();

            //Console.WriteLine("No of products out of Stock :" + result);

            
        }

        public void queryCategory(DepartmentContext context) {
            //var result = (from p in context.product
            //              join c in context.category
            //              on p.category_id equals c.category_id
            //              group p by c.category_id into x
            //              select new
            //              {
            //                  Count = x.Count<Product>(),
            //                  Category_Id = x.Key
            //              }).ToList();

            //foreach (var i in result)
            //{
            //    Console.WriteLine("Category_ID  : " + i.Category_Id);
            //    Console.WriteLine("Count : " + i.Count);
            //}

            var result = (from p in context.product
                          join c in context.category
                          on p.category_id equals c.category_id
                          group p by c.category_id into x
                          orderby x.Count<Product>() descending
                          select new
                          {
                              Count = x.Count<Product>(),
                              Category_Id = x.Key
                          }).ToList();

            foreach (var i in result)
            {
                Console.WriteLine("Category_ID  : " + i.Category_Id);
                Console.WriteLine("Count : " + i.Count);
            }
        }

        public void querySupplier(DepartmentContext context) {
            //var result = context.supplier.Where(x => x.sup_name == "Balraj Singh").ToList();
            //var result = context.supplier.Where(x => x.phone_no == "9123345785").ToList();
            //var result = context.supplier.Where(x => x.email == "rkumar@gmail.com").ToList();
            var result = context.supplier.Where(x => x.city == "Kashmeri Gate").ToList();
            foreach (Supplier i in result)
            {
                Console.WriteLine("Supplier_Id : " + i.supplier_id);
                Console.WriteLine("Name : " + i.sup_name);
                Console.WriteLine("Phone_no : " + i.phone_no);
                Console.WriteLine("Email : " + i.email);
                Console.WriteLine("City : " + i.city);
            }
        }

        public void queryProductAndSupplier(DepartmentContext context) {

            //var result = (from po in context.porder
            //              join s in context.supplier
            //              on po.supplier_id equals s.supplier_id
            //              join p in context.product
            //              on po.product_id equals p.product_id
            //              orderby po.supply_date descending
            //              select new { 
            //                ProductId = p.product_id,
            //                ProductName = p.name,
            //                SupplierId = s.supplier_id,
            //                SupplierName = s.sup_name,
            //                SupplyDate = po.supply_date
            //              }
            //              ).ToList();

            //var result = (from po in context.porder
            //              join s in context.supplier
            //              on po.supplier_id equals s.supplier_id
            //              join p in context.product
            //              on po.product_id equals p.product_id
            //              orderby po.supply_date descending
            //              where p.name =="Yipee"
            //              select new
            //              {
            //                  ProductId = p.product_id,
            //                  ProductName = p.name,
            //                  SupplierId = s.supplier_id,
            //                  SupplierName = s.sup_name,
            //                  SupplyDate = po.supply_date
            //              }
            //              ).ToList();

            //var result = (from po in context.porder
            //              join s in context.supplier
            //              on po.supplier_id equals s.supplier_id
            //              join p in context.product
            //              on po.product_id equals p.product_id
            //              orderby po.supply_date descending
            //              where s.sup_name == "Raju Rastogi"
            //              select new
            //              {
            //                  ProductId = p.product_id,
            //                  ProductName = p.name,
            //                  SupplierId = s.supplier_id,
            //                  SupplierName = s.sup_name,
            //                  SupplyDate = po.supply_date
            //              }
            //              ).ToList();

            //var result = (from po in context.porder
            //              join s in context.supplier
            //              on po.supplier_id equals s.supplier_id
            //              join p in context.product
            //              on po.product_id equals p.product_id
            //              orderby po.supply_date descending
            //              where p.product_id == 4
            //              select new
            //              {
            //                  ProductId = p.product_id,
            //                  ProductName = p.name,
            //                  SupplierId = s.supplier_id,
            //                  SupplierName = s.sup_name,
            //                  SupplyDate = po.supply_date
            //              }
            //              ).ToList();

            //var result = (from po in context.porder
            //              join s in context.supplier
            //              on po.supplier_id equals s.supplier_id
            //              join p in context.product
            //              on po.product_id equals p.product_id
            //              orderby po.supply_date descending
            //              where po.supply_date >  new DateTime(2021, 05, 15)
            //              select new
            //              {
            //                  ProductId = p.product_id,
            //                  ProductName = p.name,
            //                  SupplierId = s.supplier_id,
            //                  SupplierName = s.sup_name,
            //                  SupplyDate = po.supply_date
            //              }
            //              ).ToList();

            var result = (from po in context.porder
                          join s in context.supplier
                          on po.supplier_id equals s.supplier_id
                          join p in context.product
                          on po.product_id equals p.product_id
                          join i in context.inventory
                          on po.product_id equals i.product_id
                          orderby po.supply_date descending
                          where i.quantity > 300
                          select new
                          {
                              ProductId = p.product_id,
                              ProductName = p.name,
                              SupplierId = s.supplier_id,
                              SupplierName = s.sup_name,
                              SupplyDate = po.supply_date,
                              Quantity = i.quantity
                          }
                          ).ToList();

            foreach (var i in result) {
                Console.WriteLine("ProductId : " + i.ProductId);
                Console.WriteLine("ProductName : " + i.ProductName);
                Console.WriteLine("SupplierId : " + i.SupplierId);
                Console.WriteLine("SupplierName : " + i.SupplierName);
                Console.WriteLine("SupplyDate : " + i.SupplyDate);
                Console.WriteLine("Quantity : " + i.Quantity);
                Console.WriteLine("\n");
            }
        }
    }
}
