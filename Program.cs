
using Linq.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Linq
{
    //static class  Employees{

    // public  static List<Employees> GetEmployees()
    //    {
    //        return new List<Employees> { 
    //            new Employees(){ID=1,Name="sabreen",Address="zagazig",Lname="lname1" },
    //            new Employees(){ID=2,Name="ashraf",Address="zagazig",Lname="lname2"  },
    //            new Employees(){ID=3,Name="mohamed",Address="zagazig",Lname="lname3"  },
    //            new Employee(){ID=1,Name="feras",Address="india" ,Lname="lname4"  },
    //            new Employee(){ID=4,Name="zena",Address="turkey",Lname="lname5"   },
    //            new Employee(){ID=5,Name="samir",Address="zagazig",Lname="lname6"   },
    //            new Employee(){ID=3,Name="samira",Address="banha" ,Lname="lname7"  },
    //            new Employee(){ID=2,Name="mool",Address="assiuit",Lname="lname8"   },
    //            new Employee(){ID=5,Name="amira",Address="aswan",Lname="lname9"   },
    //            new Employee(){ID=6,Name="asmaa",Address="minia",Lname="lname10"   },
    //            new Employee(){ID=7,Name="marwan",Address="alex" ,Lname="lname11"  },
    //            new Employee(){ID=8,Name="ramy",Address="cairo",Lname="lname12"   },
    //            new Employee(){ID=9,Name="rana",Address="egypt" ,Lname="lname13"  },
    //            new Employee(){ID=10,Name="sanaa",Address="london",Lname="lname14"   },
    //            new Employee(){ID=11,Name="mona",Address="usa",Lname="lname15"   }

    //        };
    //    }
    // }
      class Program
    {
        static void Main(string[] args)
        {
            
            var numbs = new List<int> { 1, 2, 3, 4, 5, 6, 78, 9, 10 };
           
            #region Anonymous type
            //Student sabreen = new Student { Age = 28 };
            var emp = new { id = 1, name = "sabreen"};//readonly

            #endregion
            #region Linq
            #region Linq Expression and Linq Method
            #region select(projection) and where(fetch)
            //var emps= Employees.GetEmployees();
            ////var es = from e in emps //linq expression
            ////         where e.ID % 2 == 0
            ////         select e;//defer execution default
            //var result = emps.Select(c => c).ToList();//eager execution
            //emps.Add(new Employee { Address = "cairo", ID = 30, Name = "sawsn" });
            //foreach (var em in result)
            //{
            //    Console.WriteLine(em.Name + "live in "+em.Address);
            //}
            //Console.WriteLine("end");
            #endregion
            #region distinct,first,firstordefaule,last,lastordefault,single,singleordefault,skip,skipwhile,take,takewhile
            //var Namesresult = new List<string> { "sabreen", "sabreen", "Sabreen", "ashraf", "mai", "omar", "feras", "zena" };
            //foreach(var item in Namesresult.Distinct())
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(emps.Where(c => c.ID > 1).SingleOrDefault());
            List<int> skipNumbs = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //foreach(var item in skipNumbs.Skip(3))
            //{
            //    Console.WriteLine(item);
            //}
            //var results = skipNumbs.Where(n => n % 2 == 0).Min ();
            //Console.WriteLine(results);
            #endregion
            #endregion
            #region GroupBy,select,selectmany
            Parent parentone = new Parent()
            {
                Name = "Parent one",
                child = new List<Child>()
                {
                    new Child(){ID=1,Age=1,Name="child one"},
                    new Child(){ID=2,Age=4,Name="child two"}
                }
            };
            Parent parenttwo = new Parent()
            {
                Name = "Parent two",
                child = new List<Child>()
                {
                    new Child(){ID=1,Age=1,Name="child one"},
                    new Child(){ID=2,Age=4,Name="child two"}
                }
            };
            Parent parentThree = new Parent()
            {
                Name = "Parent three",
                child = new List<Child>()
                {
                    new Child(){ID=1,Age=1,Name="child one"},
                    new Child(){ID=2,Age=4,Name="child two"}
                }
            };
            var parents = new List<Parent>()
            {
                parentone,
                parenttwo,
                parentThree
            };
            var resultss = parents.Select(c => c).ToList();
            var resultsss = parents.SelectMany(c => c.child).ToList();
            var results = parents.SelectMany(c => c.child, (parent, child) => new { father = parent.Name, kids = child });
            foreach (var kids in results)
            {
                Console.WriteLine(kids);
            }
            var childs = new List<Child>()
                {
                    new Child(){ID=1,Age=1,Name="child one"},
                    new Child(){ID=2,Age=4,Name="child two"},
                    new Child(){ID=3,Age=5,Name="child one"},
                    new Child(){ID=4,Age=6,Name="child three"},
                    new Child(){ID=5,Age=7,Name="child Four"},
                    new Child(){ID=6,Age=8,Name="child Five"},
                    new Child(){ID=7,Age=9,Name="child six"},
                    new Child(){ID=8,Age=40,Name="child seven"},
                    new Child(){ID=9,Age=10,Name="child one"},
                    new Child(){ID=10,Age=47,Name="child three"}
                };
            //var results = childs.GroupBy(c => c.Name).SelectMany(c=>c.Key,(parent,child)=>new {child=parent.Key,childDetails=child});
            //foreach(var child in results)
            //{
            //    Console.WriteLine(child);


            //}
            //var results = childs.GroupBy(c => c.Name);
            //foreach (var child in results)
            //{
            //    Console.WriteLine(child.Key);
            //    foreach (var item2 in child)
            //    {
            //        Console.WriteLine(item2);
            //    }

            //}
            #endregion
            #endregion

            #region IENumberable vs iQuerable
            using(var ctx = new AdventureWorks2019Context())
            {

                var empEnumb = from add in ctx.People.TagWith("This is my enumberable query!")
                                               //where add.MiddleName != null
                                               select add;


                 var sql = ctx.People.AsEnumerable().Where(add=>add.MiddleName != null);

                IEnumerable<Person> customers = ctx.People.AsEnumerable().Where(c =>c.MiddleName!=null);
                IQueryable<Person> empQuer = ctx.People.TagWith("This is my enumberable query!")
                                              .Where(c => c.MiddleName != null);


                IQueryable<Person> empQuer2 = from addq in ctx.People.TagWith("This is my querable query!")
                                             where addq.MiddleName!=null
                                             select addq;
                var sabreenQuery = empQuer.ToQueryString();
               
                ctx.SaveChanges();
                Console.ReadKey();
             }
            //IEnumerable<Employee> empss = new IEnumerable<Employee>();
            #endregion





            Console.ReadKey();
        }
        public static System.Collections.Generic.IEnumerable<int> yieldWay(List<int> numbs)
        {



            for (int i = 4; i < 10; i++)
            {
                int result = 3;
                yield return result * i;

            }

        }
        public static System.Collections.Generic.IEnumerable<int> normalWay(List<int> numbs)
        {



            for (int i = 4; i < 10; i++)
            {
                int result = 3;
                numbs.Add(result * i);


            }
            return numbs;

        }
        public static void Foreach<T>(IEnumerable<T> source)
        {
            var numbs = source.GetEnumerator();
            IDisposable disposable;
            try
            {
                T item;
                while (numbs.MoveNext())
                {
                    item = numbs.Current;
                    Console.WriteLine($"{item}");
                }
            }
            catch
            {
                disposable = (IDisposable)numbs;
                disposable.Dispose();
            }
        }
        

    }
    class Child
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"Name is{Name} Age is{Age} ID is   {ID}";
        }

    }

    class Parent
    {
        public string Name { get; set; }
        public List<Child> child { get; set; }
        public override string ToString()
        {
            return $"Name is{Name}";
        }
    }
    
}
