// See https://aka.ms/new-console-template for more information
using PrepaMomentTech_20230918.Bll.Entities;
using PrepaMomentTech_20230918.Bll.Repositories;
using PrepaMomentTech_20230918.DalBllApp;

IContactRepository contactRepository = Locator.Instance.GetServices<IContactRepository>()!;

try
{
    foreach (Contact contact in contactRepository.Get().ToList())
    {
        Console.WriteLine($"{contact.Id:D2} : {contact.Nom} {contact.Prenom}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

