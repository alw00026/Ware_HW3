using Microsoft.Data.SqlClient;
using System.Data;
using Ware_HW3.Models;

namespace Ware_HW3.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connectionString;

        public ProductRepository(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }//end of constructor

        public List<Product> GetProductsByCategoryList(int categoryID)
        {
            List<Product> products = new List<Product>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var sqlcommand = new SqlCommand("spGetProductsByCategoryID", connection))
                {
                    sqlcommand.CommandType = CommandType.StoredProcedure;

                    sqlcommand.Parameters.AddWithValue("@categoryID", categoryID);

                    connection.Open();

                    using (var reader = sqlcommand.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            products.Add(new Product()
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                ProductCode = reader.GetString(2),
                                Description = reader.GetString(3),

                                ListPrice = reader.GetDecimal(4),
                                StandardCost = reader.GetDecimal(5),
                                ReorderLevel = reader.GetInt32(6),
                                TargetLevel = reader.GetInt32(7),
                                Discontinued = reader.GetBoolean(8),
                                SupplierID = reader.GetInt32(9),
                                AvailableQty = reader.GetInt32(10),
                                Reordered = reader.GetBoolean(11),
                                prodimage = reader.GetString(12)
                            });
                        }
                    }
                }
            }

            return products;
        }//End of GetProductsByCategoryID 

        public Product GetProductsByProductId(int productID)
        {
            Product retrievedProduct = null;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var sqlcommand = new SqlCommand("spGetProductsByProductID", connection))
                {
                    sqlcommand.CommandType = CommandType.StoredProcedure;

                    sqlcommand.Parameters.AddWithValue("@productID", productID);

                    connection.Open();

                    using (var reader = sqlcommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            retrievedProduct = new Product()
                            {
                                ProductID = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                ProductCode = reader.GetString(2),
                                Description = reader.GetString(3),

                                ListPrice = reader.GetDecimal(4),
                                StandardCost = reader.GetDecimal(5),
                                ReorderLevel = reader.GetInt32(6),
                                TargetLevel = reader.GetInt32(7),
                                Discontinued = reader.GetBoolean(8),
                                SupplierID = reader.GetInt32(9),
                                AvailableQty = reader.GetInt32(10),
                                Reordered = reader.GetBoolean(11),
                                prodimage = reader.GetString(12)
                            };
                        }
                    }

                }

            }

            return retrievedProduct;
        }//end of GetProductsByProductId method


    }

}
