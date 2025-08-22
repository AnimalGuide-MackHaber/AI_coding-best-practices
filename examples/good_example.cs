// This C# code demonstrates a well-structured class that could have been
// created with the assistance of an AI coding tool by following prompt
// engineering best practices. The comments below explain the hypothetical
// series of prompts that could have led to this result.

using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GoodExample
{
    /// <summary>
    /// Represents a service for managing user profiles.
    /// </summary>
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository for data access.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /*
         * PROMPT ENGINEERING EXAMPLE 1: Initial Creation (Persona + Specificity + Constraints)
         *
         * HYPOTHETICAL PROMPT:
         * "Act as a senior C# developer following SOLID principles. Create a C# class named 'UserService'.
         * This service should depend on two interfaces: 'IUserRepository' and 'ILogger<UserService>'.
         * Use constructor dependency injection to provide these dependencies.
         * The constructor should include null checks for the dependencies and throw an ArgumentNullException if they are null."
         *
         * WHY IT'S A GOOD PROMPT:
         * - Persona: "Act as a senior C# developer" sets a high standard for code quality.
         * - Specificity: Names the class and its exact dependencies.
         * - Constraints: Specifies the use of constructor injection and null checks, leading to robust, testable code.
        */


        /// <summary>
        /// Retrieves a user by their unique identifier and updates their last login timestamp.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A UserDto if found; otherwise, null.</returns>
        public async Task<UserDto?> GetUserByIdAsync(Guid userId)
        {
            /*
             * PROMPT ENGINEERING EXAMPLE 2: Adding a Method (Iteration + Context + Error Handling)
             *
             * HYPOTHETICAL PROMPT:
             * "In the 'UserService' class, add a public async method called 'GetUserByIdAsync' that takes a Guid 'userId' as a parameter.
             * The method should:
             * 1. Log an informational message that it is starting the operation.
             * 2. Call the 'GetByIdAsync' method on the _userRepository.
             * 3. If the user is not found, log a warning and return null.
             * 4. If the user is found, update their 'LastLoginUtc' property to DateTime.UtcNow.
             * 5. Save the changes using the repository's 'UpdateAsync' method.
             * 6. Map the user entity to a 'UserDto' object and return it.
             * 7. Wrap the entire operation in a try-catch block. If an exception occurs, log a critical error with the exception details and re-throw the exception."
             *
             * WHY IT'S A GOOD PROMPT:
             * - Iteration: It builds upon the previously generated class.
             * - Context: It refers to existing fields like `_userRepository` and `_logger`.
             * - Step-by-Step Logic: Provides a clear, numbered list of requirements.
             * - Error Handling: Explicitly asks for specific logging and exception handling behavior.
            */
            _logger.LogInformation("Attempting to retrieve user with ID: {UserId}", userId);
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);

                if (user == null)
                {
                    _logger.LogWarning("User with ID: {UserId} not found.", userId);
                    return null;
                }

                user.LastLoginUtc = DateTime.UtcNow;
                await _userRepository.UpdateAsync(user);

                _logger.LogInformation("Successfully retrieved and updated user with ID: {UserId}", userId);

                // In a real application, you would use a mapping library like AutoMapper.
                return new UserDto { Id = user.Id, Username = user.Username };
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An unexpected error occurred while retrieving user with ID: {UserId}", userId);
                throw; // Re-throw to allow higher-level exception handlers to process it.
            }
        }

        /*
         * PROMPT ENGINEERING EXAMPLE 3: Documentation (Refinement)
         *
         * HYPOTHETICAL PROMPT:
         * "Generate XML documentation for the 'GetUserByIdAsync' method. Explain what the method does,
         * describe the 'userId' parameter, and what the method returns."
         *
         * WHY IT'S A GOOD PROMPT:
         * - Refinement: Focuses on improving a specific aspect of the existing code.
         * - Clear Instructions: Specifies the exact format (XML documentation) and the content required.
        */
    }

    // Dummy interfaces and classes for context.
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task UpdateAsync(User user);
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime LastLoginUtc { get; set; }
    }

    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}


