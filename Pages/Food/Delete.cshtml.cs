using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Nutrition_App.Pages.Food
{
    public class Delete : PageModel
    {

        public void OnGet()
        {
        }
        //Get parameter from url
        public void OnPost(String name)
        {
            DeleteFood(name);//Delete food item
            Response.Redirect("/Food/Index");// redirect the user to the index page
        }

        // Connect to the database and delete the food item provided in the url using the delete statement
        private static void DeleteFood(String name)
        {
            try
            {
                string connString = "Server=.;Database=nutrition;Trusted_Connection=True;TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connString))
                {

                    connection.Open();
                    String sql = "Delete from nutrition where Food_and_Serving = " + name;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();


                    }
                }

            }
            catch (Exception e)
            {
                
                Console.WriteLine("Cannot delete customer: " + e);
            }

        }
    }
}