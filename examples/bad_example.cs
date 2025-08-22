using System;
using System.Data.SqlClient;
using System.Collections.Generic;

// This file demonstrates examples of poor quality code that can result from
// vague, incomplete, or poorly constructed prompts given to an AI coding tool.

namespace BadExample
{
    // --- Example 1: Vague Prompt ---
    //
    // BAD PROMPT: "make a class for a customer"
    //
    // WHY IT'S BAD:
    // - No context: What properties should the customer have?
    // - No constraints: Are there any validation rules? Should it be mutable or immutable?
    // - No style guide: Doesn't specify naming conventions or structure.
    //
    // RESULT: A generic, anemic class that isn't very useful.
    public class Customer
    {
        public int ID; // Public fields are bad practice. Should be properties.
        public string name; // Naming convention is inconsistent (lowercase).
    }


    // --- Example 2: Insecure Prompt ---
    //
    // BAD PROMPT: "write a function to get customer data from sql"
    //
    // WHY IT'S BAD:
    // - No security specifications: It doesn't ask for safe practices like using parameterized queries.
    // - AI models are trained on vast amounts of code, including old and insecure examples.
    //   Without explicit instructions, the AI might generate code vulnerable to SQL Injection.
    //
    // RESULT: A dangerous method that concatenates a raw string to build a SQL query.
    public class DataAccess
    {
        public List<string> GetCustomerData(string customerId)
        {
            // VULNERABILITY: This code is susceptible to SQL Injection.
            // If a malicious user provides an input like "' OR 1=1 --",
            // they could retrieve all customer data.
            string query = "SELECT * FROM Customers WHERE CustomerId = '" + customerId + "'";

            var connectionString = "Server=myServer;Database=myDataBase;User Id=myUser;Password=myPassword;";
            var results = new List<string>();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(reader["CustomerName"].ToString());
                }
            }
            return results;
        }
    }


    // --- Example 3: Non-Specific Logic Prompt ---
    //
    // BAD PROMPT: "process a list of items"
    //
    // WHY IT'S BAD:
    // - Too generic: "Process" means nothing. What is the goal?
    // - No error handling specified: What should happen if an item is invalid?
    // - Inefficient: Doesn't provide any performance constraints.
    //
    // RESULT: A function that does something, but it's probably not what you wanted.
    // It's inefficient (loops inside a loop) and has poor error handling (swallows exceptions).
    public class Processor
    {
        public void ProcessItems(List<string> items, List<string> validationRules)
        {
            foreach (var item in items)
            {
                try
                {
                    // Inefficient: This is an O(n*m) operation. A HashSet for validationRules
                    // would be much more performant (O(n)). The AI won't know this unless told.
                    foreach (var rule in validationRules)
                    {
                        if (item.Contains(rule))
                        {
                            Console.WriteLine($"Item {item} is valid according to rule {rule}");
                        }
                    }
                }
                catch (Exception)
                {
                    // Bad Practice: Swallowing exceptions hides problems in the code.
                    // The prompt didn't specify logging or re-throwing, so the AI chose the worst option.
                }
            }
        }
    }
}


