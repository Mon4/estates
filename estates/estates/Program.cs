﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    /// <summary>
    /// kind of meetings can be selling when we sell estate or watching
    /// </summary>
    public enum KindOfMeeting { watching, selling }

    internal class Program
    {
        static void Main(string[] args)
        {
            PrivateOwner po1 = new PrivateOwner(adress: "ul. Kwiatowa 4", zipCode: "32-123", city: "Kraków", phoneNumber: "123056789", name: "Mariusz", surname: "Grzyb");
         
            Client c1 = new Client(name: "Jan", surname: "Kowalski", phoneNumber: "512132546", date: "15.12.1980");
            
            Employee e1 = new Employee(name: "Janina", surname: "Nowak", phoneNumber: "801234123", salary: 2500);
            
            House h1 = new House(adress: "ul. Niebieska 14", zipCode: "31-642", city:"Kraków", price: 50000, area: 50, furniture: true, balcony: true, roomsNumber:4, 
                description:"nice house", bedrooms:2, owner: po1, levels:2, garden: true, gardenArea:20);
            
            Flat f1 = new Flat(adress: "ul. Mickiewicza 1", zipCode:"32-123", city:"Kraków", price: 400000, area:90, furniture:true, balcony:false, roomsNumber:5,
                description: "nice flat", bedrooms: 1, owner: po1, building_development: "kamienica", level:10);
            
            Meeting m1 = new Meeting(client: c1, employee: e1, estate: h1, date: "12.12.2021 16:00", KindOfMeeting.selling);
            
            Company co1 = new Company(adress:"ul. Zielona 12", zipCode:"23-534", city:"Kraków", phoneNumber:"123456789", nip:"123-123-12-12", companyName:"BUDUJEMY_SE");

            OwnersRepository or1 = new OwnersRepository("List of owners");

            EstatesRepository est1 = new EstatesRepository("List of estates");

            ClientsRepository crep1 = new ClientsRepository("List of clients");

            EmployeesRepository empr1 = new EmployeesRepository("List of employees");

            MeetingsRepository meet1 = new MeetingsRepository("List of meetings");
            meet1.AddMeeting(m1);
            meet1.SaveToXML();
            crep1.AddClient(c1);
            crep1.SaveToXML();
            or1.AddOwner(co1);
            or1.AddOwner(po1);
            est1.AddEstate(h1);
            est1.AddEstate(f1);
            est1.SaveToXML();
            empr1.AddEmployee(e1);
            empr1.SaveToXML();
            or1.SaveToXML();
            System.Console.WriteLine(e1);
            System.Console.WriteLine(m1);
            System.Console.WriteLine(co1);
            System.Console.WriteLine(f1);
            Console.WriteLine(EstatesRepository.ReadXML());
            Console.WriteLine(OwnersRepository.ReadXML());
            Console.WriteLine(ClientsRepository.ReadXML());
            Console.WriteLine(EmployeesRepository.ReadXML());
            Console.WriteLine(MeetingsRepository.ReadXML());
            Console.WriteLine(EstatesRepository.ReadXML());

            Console.ReadKey();
        }
    }
}
