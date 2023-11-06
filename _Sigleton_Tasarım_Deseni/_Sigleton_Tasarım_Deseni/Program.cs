using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Sigleton_Tasarım_Deseni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Singleton Design Pattern, bir sınıftan yalnızca bir nesne üretilebilmesini
            //garanti eder ve diğer sınıfların(yeni nesne üretmeleri yerine) bu nesneye erişebilmelerine olanak sağlar.
            //Varoluşsal(Creational) tasarım desenlerinden biridir

            // Customer customer = new Customer(); Bu şekilde new leme yapmanıza izin vermez 

            var customerManager = Customer.CreateAsSigleteton();
            customerManager.Save();
            Console.ReadLine();

        }
    }
    
}
class Customer
{
    private static Customer _customer; // Field
     static object _lockObjet = new object();
    private Customer() // Burda Bu constructor Metot Sayesinde başka bir Sınıftan new lenmez hale getirdik Burda private kullanma amacımız budur 
    {
        
    }
    
    public static Customer CreateAsSigleteton()
    {
        lock (_lockObjet)
        {


            if (_customer == null)// Burda Gelen _customer eğer başka bir yerde kullanılmadıysa bir adet obje oluşuştur
            {
                _customer = new Customer();

            }
        }
        return _customer; // Varsa direk Geri Döndür 
    }
    public void Save()
    {
        Console.WriteLine("SAVE!!");
    }
}
