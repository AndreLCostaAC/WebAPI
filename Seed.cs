
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.UserTickets.Any())
            {
                var userTickets = new List<UserTickets>()
                {
                    new UserTickets()
                    {
                        User = new User()
                        {
                            Company = Enum.Company.VTXRM,
                            Name = "André Lopes Costa",
                            Email = "aloc@vtx.com",
                            JobPosition = Enum.JobPosition.TechnicalConsultant,
                            DKX = "AHSA12",
                            Country = new Country()
                            {
                                Name = "Portugal"
                            },
                        },
                        Tickets = new Tickets()
                        {
                            Name = "VTX-112",
                            Responsibles = new List<User>()
                            {
                                new User
                                {
                                    Company = Enum.Company.VTXRM,
                                    Name = "José António",
                                    Email = "Jose@vtxrm.com",
                                    JobPosition = Enum.JobPosition.FunctionalConsultant,
                                    DKX = "21ADW",
                                    Country = new Country(){Name = "Portugal"}
    
                                },
                                new User
                                {
                                    Company = Enum.Company.GOOGLE,
                                    Name = "Ana Maria",
                                    Email = "maria@vtxrm.com",
                                    JobPosition = Enum.JobPosition.FunctionalConsultant,
                                    DKX = "21A12DW",
                                    Country = new Country(){Name = "Portugal"}

                                }
                            },
                            Creator = new User()
                            {
                                    Company = Enum.Company.GOOGLE,
                                    Name = "Michael Smith",
                                    Email = "smith@google.com",
                                    Country = new Country(){Name = "USA"}
                            },
                            Created = new DateTime(2023,1,1),
                            Updated = DateTime.Now,
                            Organization = new Client()
                            {
                                Name = Enum.Company.GOOGLE,
                                HoursPackage = true,
                                Country = new Country(){Name = "USA"},

                                
                            },
                            RequestType = Enum.RequestType.Error,
                            Description = "Resolved",
                        }
                    },
                    new UserTickets()
                    {
                        User = new User()
                        {
                            Company = Enum.Company.VTXRM,
                            Name = "Ana Goncalves",
                            Email = "ana@vtx.com",
                            JobPosition = Enum.JobPosition.FunctionalConsultant,
                            DKX = "1231JK",
                            Country = new Country()
                            {
                                Name = "Portugal"
                            },
                        },
                        Tickets = new Tickets()
                        {
                            Name = "VTX-122",
                            Responsibles = new List<User>()
                            {
                                new User
                                {
                                    Company = Enum.Company.VTXRM,
                                    Name = "Filipe Costa",
                                    Email = "Filipe@vtxrm.com",
                                    JobPosition = Enum.JobPosition.Tester,
                                    DKX = "1ASD21",
                                    Country = new Country(){Name = "Portugal"}

                                },
                                new User
                                {
                                    Company = Enum.Company.VTXRM,
                                    Name = "Leonor Azevedo",
                                    Email = "Leonor@vtxrm.com",
                                    JobPosition = Enum.JobPosition.Tester,
                                    DKX = "1ASD21",
                                    Country = new Country(){Name = "Spain"}

                                }
                            },
                            Creator = new User()
                            {
                                    Company = Enum.Company.NETFLIX,
                                    Name = "Mark Tate",
                                    Email = "tate@netflix.com",
                                    Country = new Country(){Name = "USA"}
                            },
                            Created = new DateTime(2023,12,12),
                            Updated = DateTime.Now,
                            Organization = new Client()
                            {
                                Name = Enum.Company.NETFLIX,
                                HoursPackage = false,
                                Country = new Country(){Name = "USA"},


                            },
                            RequestType = Enum.RequestType.ChangeRequest,
                            Description = "Deployed",
                        }
                    }

                };
                dataContext.UserTickets.AddRange(userTickets);
                dataContext.SaveChanges();
            }
        }
    }
}
