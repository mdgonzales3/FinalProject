namespace FinalProject;
using System.Data;
using MySql.Data.MySqlClient;
class BusinessLogic
{
   
    static void Main(string[] args)
    {
        bool _continue = true;
        User user;
        GuiTier appGUI = new GuiTier();
        DataTier database = new DataTier();

        // start GUI
        user = appGUI.Login();

       
        if (database.LoginCheck(user)){

            while(_continue){
                int option  = appGUI.Dashboard(user);
                switch(option)
                {
                    // check enrollment
                    case 1:
                        DataTable tableResidents = database.CheckResident(user);
                        if(tableResidents != null)
                            appGUI.DisplayResidents(tableResidents);
                        break;
                    // Add A Course
                    case 2:
                        DataTable tablePending = database.AddPackage(user);
                        if(tablePending != null)
                            appGUI.DisplayPending(tablePending);
                        break;
                    // Drop A Course
                    case 3:
                        Console.WriteLine("To Be Implemented");
                        break;
                    // Log Out
                    case 4:
                        _continue = false;
                        Console.WriteLine("Log out, Goodbye.");
                        break;
                    // default: wrong input
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }

            }
        }
        else{
                Console.WriteLine("Login Failed, Goodbye.");
        }        
    }    
}
