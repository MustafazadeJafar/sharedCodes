namespace ConsoleApp5.Core.Services;

public class UserService
{
    public static int Register(string name, string surname, string username, string password)
    {
        //hash password
        /*
        INSERT INTO Users(username, password_hash)
        VALUES('johndoe', HASHBYTES('SHA2_512', 'supersecretpassword'));
        The password is hashed via SHA2_512 before being stored in the database. The same user can then be authenticated by hashing the entered password and comparing it:

        SELECT username
        FROM Users
        WHERE password_hash = HASHBYTES('SHA2_512', 'enteredpassword');
        */



        return 0;
    }

    public static bool Login(string username, string password)
    {

    }
}
