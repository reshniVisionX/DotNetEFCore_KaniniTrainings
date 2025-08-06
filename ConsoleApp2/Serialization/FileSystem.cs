using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    internal class FileSys
    {
        public void FileMain()
        {
            Account acc = new Account()
            {
                acc_id = 121,
                name = "Canara",
                branch = "vellalore"
            };
            // Serialization 
            String json = JsonConvert.SerializeObject(acc);
            Console.WriteLine(json);
            // file concept to store object data into a file
            FileStream fs = new FileStream("Sample.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs); 
            Console.WriteLine(sr.ReadToEnd());

            Account desc = JsonConvert.DeserializeObject<Account>(json)!;
            Console.WriteLine(desc.acc_id+" "+desc.name+" "+desc.branch);
            fs.Close();

        }
    }
    class Account
    {
        public int acc_id;
        public string name;
        public string branch;

    
    }
}
