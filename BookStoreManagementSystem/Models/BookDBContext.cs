namespace BookStoreManagementSystem.Models {
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class S4452232 {

        [Required(ErrorMessage = "The field Index is required.")]
        public int Index { get; set; }

        [Required(ErrorMessage = "The field ID is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "The field ID must be a 10-digit number.")]
        public string ID { get; set; }

        [Required(ErrorMessage = "The field Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field Author is required.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "The field Year is required.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "The field Year must be a 4-digit number.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "The field Price is required.")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field Stock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The field Stock cannot be negative.")]
        public int Stock { get; set; }
    }

    public class BookDBContext : DbContext {
        // Your context has been configured to use a 'BookDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookStoreManagementSystem.Models.BookDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookDBContext' 
        // connection string in the application configuration file.
        public BookDBContext()
            : base("name=BookDBContext") {
        }

        public System.Data.Entity.DbSet<BookStoreManagementSystem.Models.S4452232> S4452232 { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}