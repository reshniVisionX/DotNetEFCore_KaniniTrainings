using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    //High-level modules shouldn’t depend on low-level modules. Both should depend on abstractions.
    //Avoids tightly coupling high-level classes (which contain business logic) with low-level classes (which contain implementation).
    //Using only email service is tight coupling
    public interface IMessage
    {
        void SendUser(String name,String sender);
    }
    public class EmailService:IMessage
    {
        public void SendUser(String name, String sender)
        {
            Console.WriteLine($"Sending Email to {name} of email id {sender}" );
        }
    }
    public class NotifyService:IMessage
    {
        public void SendUser( String name, String sender)
        {
            Console.WriteLine($"Sending message to {name} with mobile number {sender}");
        }
    }
    public class Messaging
    {
        private IMessage mes;
        public Messaging(IMessage mes)
        {
            this.mes = mes;
        }
        public void start(String name,String sender)
        {
            mes.SendUser(name,sender);
        }
    }
    public class DependencyInversionPrinciple
    {
        public void Main()
        {
            String user = "Reshni";
            String phno = "8878789890";
            String mail = "reshni@gmail.com";

            IMessage email = new EmailService();
            Messaging emes = new Messaging(email);
            emes.start(user, mail);

            IMessage not = new NotifyService();
            Messaging nmes = new Messaging(not);
            nmes.start(user, phno);
        }


    }
}
