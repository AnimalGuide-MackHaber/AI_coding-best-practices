# **Best Practices for Prompt Engineering**

Effective prompt engineering is the single most important skill for getting high-quality, relevant, and secure code from an AI assistant. The quality of the output is directly proportional to the quality of the input.

### **1\. Be Specific and Provide Context**

Vague prompts lead to generic and often useless code. Provide as much detail as possible about your requirements.

* **Bad Prompt**: "Write a function that sorts a list."  
* **Good Prompt**: "Write a C\# function that sorts a list of User objects by their LastName property in ascending order. If two users have the same last name, sort them by their FirstName. The function should handle null or empty lists gracefully by returning an empty list."

### **2\. Define the Persona**

Tell the AI to act as a specific type of expert. This helps frame the response in the desired context, style, and complexity.

* **Prompt Example**: "Act as a senior C\# developer specializing in secure cloud applications. Write a method to upload a file to an Azure Blob Storage container. Ensure you use the latest Azure SDK for .NET and include robust error handling and logging."

### **3\. Provide Examples (Few-Shot Prompting)**

Give the AI an example of the input you have and the output you want. This is one of the most effective ways to guide it toward the desired format and logic.

* **Prompt Example**: "I have a C\# class public class User { public int Id { get; set; } public string Name { get; set; } }. I want to convert it to a DTO public class UserDto { public string UserName { get; set; } }. Based on this, generate a C\# function using AutoMapper to map the User entity to the UserDto."

### **4\. Iterate and Refine**

Your first prompt may not yield the perfect result. Treat the interaction as a conversation. Ask the AI to refine, refactor, or add to its previous response.

* **Initial Prompt**: "Create a C\# class for a Product."  
* **Follow-up Prompt 1**: "Add properties for ID, Name, Price, and Description. Use data annotations for validation: Name is required, and Price must be between 0 and 10,000."  
* **Follow-up Prompt 2**: "Now, refactor this into an immutable record."  
* **Follow-up Prompt 3**: "Add XML documentation to the record and its properties."

### **5\. Explicitly State Constraints and Requirements**

Clearly state what the AI *should* and *should not* do. This includes specifying libraries, frameworks, language versions, and security practices.

* **Prompt Example**: "Write a LINQ query in C\# to find all users who have registered in the last 30 days. Use DateTime.UtcNow for the comparison. Do not use any external libraries other than System.Linq."
