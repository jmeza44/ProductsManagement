using ProductsManagement.Data.Models;

namespace ProductsManagement.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product()
                        {
                            Code = "5a8d4a9b-ce9c-4971-9c9d-a973270fe4b3",
                            Description= "Live you best vacation in the world, wake up every morning to a sea view that will take your breath away and enjoy a follow - up of sunsets. Apartment on the beach is located across the street from Playa Linda neighborhood where famous bars and restaurants enjoy an incomparable nightlife. Stay with us and breathe clean air everyday. Your new home is ready now, thank us later for giving you a space of peace, love & freedom.",
                            Type= "Property",
                            Value= 1500000,
                            BoughtDate= DateTime.Now.AddDays(-10),
                            State= "Active",
                        },
                        new Product()
                        {
                            Code = "e81c6907-2feb-4be7-be3e-2f791226538d",
                            Description = "Would you like to wake up in front of the sea, breath clean air and enjoy on the beach. You've found your home at Apartment On The Beach! Our studio is located in a quiet part of town but that doesn't mean we're isolated from all amenities. We're just minutes away from Waldo Point car park which has some great cafes and restaurants, Westfield Pitt St shopping centre (an Amazon if you will), multiple buses services and Mt Gravatt train station. And as if that's not enough, our location also takes us straight onto the beach where guests can walk for miles in either direction. We know this is 10 times better than being stuck in an apartment complex. Our building itself is absolutely stunning with modern comforts and a relaxing outdoor area making us one of the best places to stay in Brisbane. ",
                            Type = "Property",
                            Value = 220000,
                            BoughtDate = DateTime.Now.AddDays(-5),
                            State = "Inactive",
                        },
                        new Product()
                        {
                            Code = "7cd5c342-7702-4e9a-a419-4e41ff9ee80d",
                            Description = "Are you looking for your new home where you can wake up in front of the sea, breathe clean air and enjoy on the beach. Apartment On The Beach will give you peace of mind with its well - kept pool area and secure gated entrance. You deserve to relax after a long day at work or while spending time with family and friends. Welcome to your paradise! ",
                            Type = "Property",
                            Value = 850000,
                            BoughtDate = DateTime.Now.AddDays(-30),
                            State = "Active",
                        },
                        new Product()
                        {
                            Code = "f21beb21-61e6-4527-ba46-084ad71b171d",
                            Description = "His childhood passes in the familiar house of the street En Bou of Valencia right in the centre of the map of the city. The transition from one stage to another gives him a vibrational feeling that encourages us to stay, feels and tell more stories until we can \"move and live\" them beyond the wall like characters ready made on canvas and with paintbrush. Through his art he wants us all to feel alive; \"to share what is true in each moment because everything will be okay\". ",
                            Type = "Apartment",
                            Value = 2199000,
                            BoughtDate = DateTime.Now.AddDays(-14),
                            State = "Inactive",
                        },
                        new Product()
                        {
                            Code = "a1fe1fce-a712-43e2-98a8-2bbef1ee49fa",
                            Description = "The street En Bou runs through the childhood of Valencia, where his childhood passes in a familiar house. In fact, many families live there with grandparents, parents and children. It is in this place that Marlon recalls moments of happiness as well as poignant ones of sadness. He will pass by these places often, painting their memories to treasure them later on when he decides to move out of his childhood home and into adult life.",
                            Type = "Apartment",
                            Value = 1200000,
                            BoughtDate = DateTime.Now.AddDays(-2),
                            State = "Active",
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
