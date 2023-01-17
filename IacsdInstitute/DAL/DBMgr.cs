namespace DAL;
using BOL;
using MySql.Data.MySqlClient;


public class DBMgr
{
    public static string myconnectionString=@"server=localhost;
                                            user=root;
                                            password=password;
                                            database=wpt;
                                            port=3306";

    public static List<User> Getalluserslist(){
    List<User> alluserlist=new List<User>();
    MySqlConnection mysqlcon=new MySqlConnection();
    mysqlcon.ConnectionString=myconnectionString;

    try{
        mysqlcon.Open();
        MySqlCommand mysqlcommand=new MySqlCommand();
        mysqlcommand.Connection=mysqlcon;
        string query="select * from user";
        mysqlcommand.CommandText=query;
        MySqlDataReader mysqldatareader=mysqlcommand.ExecuteReader();

        while (mysqldatareader.Read())
        {
            string firstname=mysqldatareader["firstname"].ToString()!;
            string lastname=mysqldatareader["lastname"].ToString()!;
            string email=mysqldatareader["email"].ToString()!;
            string password=mysqldatareader["password"].ToString()!;
            

            User user=new User
            {
             Firstname=firstname,
             Lastname=lastname,
             Email=email,
             Password=password
            };
            alluserlist.Add(user);
        }
    }catch(Exception e){
        Console.WriteLine(e.Message);

    }
    finally{
        mysqlcon.Close();
    }

    return alluserlist;
     }


    public static bool InsertUser(User user){
        bool status=false;
        //string query1="Insert into user("+"'"+user.Firstname+"','"+user.Lastname+"'"+"'"+user.Email+"'"+"'"+user.Password+"'"+")";
        string query="Insert into user('"+user.Firstname+"','"+user.Lastname+"','"+user.Email+"','"+user.Password+"')";
        MySqlConnection mySqlConnection=new MySqlConnection();
        mySqlConnection.ConnectionString=myconnectionString;
        //MySqlConnection 
        //MySqlCommand
        
        try{
            mySqlConnection.Open();
            MySqlCommand mysqlcommand=new MySqlCommand();
            mysqlcommand.ExecuteNonQuery();
            status=true;

        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            mySqlConnection.Close();
        }
        
        return status;
    }





}