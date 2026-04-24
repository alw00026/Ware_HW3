using Microsoft.Data.SqlClient;
using Ware_HW3.Models;

namespace Ware_HW3.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string connectionString;

        public CategoryRepository(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }//end of constructor


        public List<Category> GetCategoryList()
        {

            List<Category> categories = new List<Category>();

            //Create a connection
            using (var connection = new SqlConnection(connectionString))
            {

                //create a command object and provide values for the parameters
                using (var command = new SqlCommand("spGetAllCategories", connection))
                {
                    //open the connection

                    connection.Open();

                    //run the command
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Category
                            {
                                CategoryID = reader.GetInt32(0),
                                CategoryName = reader.GetString(1),
                            });
                        }

                    }
                }

                //close the connection
                connection.Close();
            }

            return categories;

        }//end of GetProductsByCategoryID method

    }
}
