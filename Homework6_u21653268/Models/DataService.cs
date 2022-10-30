using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Homework6_u21653268.Models
{
    public class DataService
    {
        private string ConnectionString;

        public DataService()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Order> getAllOrders()
        {
            List<Order> orders = new List<Order>();
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection currConnection = new SqlConnection(ConnectionString);
                currConnection.Open();

                string sqlQuery = "Select sales.orders.order_id as OrderID, sales.orders.order_date as Date, sales.orders.store_id as StoreID" +
                    " from sales.orders Order By sales.orders.order_id";
                SqlCommand command = new SqlCommand(sqlQuery, currConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order someOrder = new Order();
                        someOrder.order_id = Convert.ToInt32(reader["OrderID"]);
                        someOrder.order_date = Convert.ToDateTime(reader["Date"]);
                        someOrder.store_id = Convert.ToInt32(reader["StoreID"]);

                        orders.Add(someOrder);
                    }
                }
                currConnection.Close();
            }
            catch
            {

            }
            return orders;
        }

        public List<ReportVM> getReportData()
        {
            List<ReportVM> data = new List<ReportVM>();
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection currConnection = new SqlConnection(ConnectionString);
                currConnection.Open();

                string sqlQuery = "select DATENAME(month,CONVERT(datetime,sales.orders.order_date,103)) as [Month], COUNT(sales.order_items.quantity) as Amount" +
                    " from sales.orders inner join sales.order_items on sales.orders.order_id = sales.order_items.order_id" +
                    " inner join production.products on sales.order_items.product_id = production.products.product_id" +
                    " inner join production.categories on production.products.category_id = production.categories.category_id" +
                    " where production.categories.category_id = '6'" +
                    " group by MONTH(sales.orders.order_date), DATENAME(month,CONVERT(datetime,sales.orders.order_date,103))" +
                    " ORDER BY MONTH(sales.orders.order_date)";
                SqlCommand command = new SqlCommand(sqlQuery, currConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReportVM someData = new ReportVM();
                        someData.numSold = Convert.ToInt32(reader["Amount"]);
                        someData.month = Convert.ToString(reader["Month"]);
                        data.Add(someData);
                    }
                }
                currConnection.Close();
            }
            catch
            {

            }
            return data;
        }

        public List<Order> getAllSearchedOrders(DateTime date)
        {
            List<Order> orders = new List<Order>();
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection currConnection = new SqlConnection(ConnectionString);
                currConnection.Open();

                string sqlQuery = "Select sales.orders.order_id as OrderID, sales.orders.order_date as Date, sales.orders.store_id as StoreID" +
                    " from sales.orders " +
                    " WHERE sales.orders.order_date = '" + date + "'" +
                    " Order By sales.orders.order_id";
                SqlCommand command = new SqlCommand(sqlQuery, currConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order someOrder = new Order();
                        someOrder.order_id = Convert.ToInt32(reader["OrderID"]);
                        someOrder.order_date = Convert.ToDateTime(reader["Date"]);
                        someOrder.store_id = Convert.ToInt32(reader["StoreID"]);

                        orders.Add(someOrder);
                    }
                }
                currConnection.Close();
            }
            catch
            {

            }
            return orders;
        }

        public List<OrderItem> getOrderItems(int order_id)
        {
            List<OrderItem> orders = new List<OrderItem>();
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection currConnection = new SqlConnection(ConnectionString);
                currConnection.Open();

                string sqlQuery = "Select sales.orders.order_id as OrderID, sales.order_items.item_id as ItemID, sales.order_items.product_id as ProductID, sales.order_items.quantity as Quantity, sales.order_items.list_price as ListPrice" +
                    " from sales.orders Inner join sales.order_items on sales.orders.order_id = sales.order_items.order_id " +
                    " WHERE sales.orders.order_id = '" + order_id + "'";
                SqlCommand command = new SqlCommand(sqlQuery, currConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderItem someOrder = new OrderItem();
                        someOrder.order_id = Convert.ToInt32(reader["OrderID"]);
                        someOrder.item_id = Convert.ToInt32(reader["ItemID"]);
                        someOrder.product_id = Convert.ToInt32(reader["ProductID"]);
                        someOrder.quantity = Convert.ToInt32(reader["Quantity"]);
                        someOrder.list_price = Convert.ToDecimal(reader["ListPrice"]);

                        orders.Add(someOrder);
                    }
                }
                currConnection.Close();
            }
            catch
            {

            }
            return orders;
        }

        public List<StoreProduct> getProductsPerStore(int product_id)
        {
            List<StoreProduct> storeProducts = new List<StoreProduct>();
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection currConnection = new SqlConnection(ConnectionString);
                currConnection.Open();

                string sqlQuery = "Select sales.stores.store_id as StoreID, sales.stores.store_name as StoreName, production.stocks.quantity as Quantity" +
                    " from sales.stores Inner join production.stocks on production.stocks.store_id = sales.stores.store_id " +
                    " WHERE production.stocks.product_id = '" + product_id + "'";
                SqlCommand command = new SqlCommand(sqlQuery, currConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StoreProduct someStoreProduct = new StoreProduct();
                        someStoreProduct.store_id = Convert.ToInt32(reader["StoreID"]);
                        someStoreProduct.store_name = Convert.ToString(reader["StoreName"]);
                        someStoreProduct.quantity = Convert.ToInt32(reader["Quantity"]);

                        storeProducts.Add(someStoreProduct);
                    }
                }
                currConnection.Close();
            }
            catch
            {

            }
            return storeProducts;
        }
    }
}