// See https://aka.ms/new-console-template for more information
using SolidPrinciples;

Console.WriteLine("-- Interface Segregation Principle --");

InterfaceSegregationPrinciple isp = new InterfaceSegregationPrinciple();
isp.Start();
Console.WriteLine();
Console.WriteLine("-- Dependency Inversion Principle --");
DependencyInversionPrinciple dip = new DependencyInversionPrinciple();
dip.Main();

Console.WriteLine("\n-- LiskovPrinciple --");
LiskovPrinciple lp = new LiskovPrinciple();
lp.Start();

Console.WriteLine("\n-- SingleResponsibiltyPrinciple --");
SingleResponsibiltyPrinciple srp = new SingleResponsibiltyPrinciple();
srp.Start();

Console.WriteLine("\n-- Open Close--");
OpenCloseMain oc = new OpenCloseMain();
oc.start();