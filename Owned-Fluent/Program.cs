using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Owned_Fluent.Context;

namespace Owned_Fluent
{
    class Program
    {
        const int thread = 32;
        public static  readonly Stopwatch _Stopwatch = new Stopwatch();

        public static void ValueType(int valor)
        {
            valor = 10;
        }

        public static void ReferenceType(ref int valor)
        {
            valor = 10;
        }
        static void Main(string[] args)
        {

            var valor = 20;

            ValueType(valor);


            Console.WriteLine(valor);

            ReferenceType(ref valor);
            Console.WriteLine(valor);
            //Console.WriteLine("Loading database !!!");
        

            //var service = new ServiceCollection()
            //    .AddEntityFrameworkSqlServer()
            //    .AddDbContext<DataContext>(c => c.UseSqlServer(""))
            //    .BuildServiceProvider();

            //DatabaseBind();

            //var tasks = new Task[thread];
            //for (int i = 0; i < thread; i++)
            //{
            //    tasks[i] = SimulateContext();

            //}
            //Task.WhenAll(tasks).Wait();

            //using (var context = new DataContext())
            //{
            //   var wait = new Stopwatch();

            //    wait.Start();
            //    var agenda = context.Agenda;
            //    wait.Stop();

            //    Console.WriteLine(wait.ElapsedMilliseconds);
            //    wait.Start();
            //    var comercial = context.Agenda;
            //    wait.Stop();
            //    Console.WriteLine(wait.ElapsedMilliseconds);

            //}
            Console.ReadKey();
            
        }

        //private static Task SimulateContext(IServiceProvider service)
        //{
        //    while (_Stopwatch.IsRunning)
        //    {
                
        //    }
        //}

        private static void DatabaseBind()
        {
            using (var context = new DataContext())
            {

                Console.Write("Delete database...");
                if (context.Database.EnsureDeleted())
                {
                    Console.WriteLine("done");
                    Console.Write("Create database...");
                    context.Database.EnsureCreated();
                    Console.WriteLine("done");
                    Console.Write("Insert Data...");
                    context.Agenda.Add(new Agenda()
                    {
                        Nome = "Junior Porfirio",
                        Residencial = new Contato()
                        {
                            Telefone = "19-9999-9999",
                            Email = "jp@residencial.com"
                        },
                        Comercial = new Contato()
                        {
                            Telefone = "19-9999-9999",
                            Email = "jp@comercial.com"
                        }
                    });

                    context.SaveChanges();
                    Console.WriteLine("done");

                }
            }
        }
    }
}
