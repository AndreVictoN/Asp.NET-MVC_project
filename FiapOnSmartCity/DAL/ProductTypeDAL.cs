using Oracle.ManagedDataAccess.Client;
using FiapOnSmartCity.Models;
using FiapOnSmartCity.DAL.Context;

namespace FiapOnSmartCity.DAL;

public class ProductTypeDAL
{
    //private readonly IConfiguration _configuration;
    private readonly string? _connectionString;

    public ProductTypeDAL(/*IConfiguration configuration*/)
    {
        //_configuration = configuration;
        _connectionString = Environment.GetEnvironmentVariable("LocalConnection");
    }

    //WITH ENTITY FRAMEWORK
    public IList<ProductType> GetAll()
    {
        return new ContextClass().ProductType.OrderBy(p => p.id).ToList();
    }

    public ProductType GetById(int id)
    {
        ContextClass context = new ContextClass();
        ProductType? productType = context.ProductType.Find(id);
        
        return productType;   
    }
    
    public void Create(ProductType productType)
    {
        ContextClass context = new ContextClass();

        context.ProductType.Add(productType);
        context.SaveChanges();
    }

    public void Update(ProductType productType)
    {
        ContextClass context = new ContextClass();

        context.Entry(productType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //context.ProductType.Update(productType);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        ContextClass context = new ContextClass();

        ProductType? productType = context.ProductType.Find(id);

        if(productType != null) context.Entry(productType).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        context.SaveChanges();
    }

    //WITHOUT ENTITY FRAMEWORK
    /*
    public IList<ProductType> GetAll()
    {
        IList<ProductType> list = new List<ProductType>();
        //var connectionString = _configuration.GetConnectionString("LocalConnection");
        //var connectionString = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("LocalConnection");
        
        try
        {
            using(OracleConnection connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT * FROM PRODUCT_TYPE";
                OracleCommand command = new OracleCommand(query, connection);

                connection.Open();

                OracleDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    ProductType productType = new ProductType
                    {
                        id = Convert.ToInt32(reader["IDPRODUCT"]),
                        description = reader["PROD_DESCRIPTION"].ToString(),
                        isComercialized = Convert.ToInt32(reader["IS_COMERCIALIZED"]) == 1 ? true : false
                    };

                    list.Add(productType);
                }

                connection.Close();
            }
        } catch(Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        return list;
    }

    public ProductType GetById(int id)
    {
        //var connectionString = _configuration.GetConnectionString("LocalConnection");

        ProductType? productType = new ProductType();

        try
        {
            using(OracleConnection connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT * FROM PRODUCT_TYPE WHERE IDPRODUCT = :id";
                OracleCommand command = new OracleCommand(query, connection);

                command.Parameters.Add("id", id);
                connection.Open();

                OracleDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    productType.id = Convert.ToInt32(reader["IDPRODUCT"]);
                    productType.description = reader["PROD_DESCRIPTION"].ToString();
                    productType.isComercialized = Convert.ToInt32(reader["IS_COMERCIALIZED"]) == 1 ? true : false;
                }

                connection.Close();
            }
        } catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        
        return productType;
    }

    public void Create(ProductType productType)
    {
        //var connectionString = _configuration.GetConnectionString("LocalConnection");

        try
        {
            using(OracleConnection connection = new OracleConnection(_connectionString))
            {
                string query = "INSERT INTO PRODUCT_TYPE (PROD_DESCRIPTION, IS_COMERCIALIZED) VALUES (:prodDescription, :isComercialized)";
                OracleCommand command = new OracleCommand(query, connection);

                command.Parameters.Add("prodDescription", OracleDbType.Varchar2).Value = productType.description;
                command.Parameters.Add("isComercialized", OracleDbType.Int32).Value = productType.isComercialized ? 1 : 0;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        } catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public void Update(ProductType productType)
    {
        //var connectionString = _configuration.GetConnectionString("LocalConnection");

        try
        {
            using(OracleConnection connection = new OracleConnection(_connectionString))
            {
                string query = "UPDATE PRODUCT_TYPE SET PROD_DESCRIPTION = :prodDescription, IS_COMERCIALIZED = :isComercialized WHERE IDPRODUCT = :id";
                OracleCommand command = new OracleCommand(query, connection);

                command.Parameters.Add("prodDescription", OracleDbType.Varchar2).Value = productType.description;
                command.Parameters.Add("isComercialized", OracleDbType.Int32).Value = productType.isComercialized ? 1 : 0;
                command.Parameters.Add("id", OracleDbType.Int32).Value = productType.id;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        } catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public void Delete(int id)
    {
        //var connectionString = _configuration.GetConnectionString("LocalConnection");

        try
        {
            using(OracleConnection connection = new OracleConnection(_connectionString))
            {
                string query = "DELETE FROM PRODUCT_TYPE WHERE IDPRODUCT = :id";
                OracleCommand command = new OracleCommand(query, connection);
                command.Parameters.Add("id", OracleDbType.Int32).Value = id;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        } catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }*/
}