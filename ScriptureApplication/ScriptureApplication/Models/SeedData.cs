using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ScriptureApplication.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScriptureApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<ScriptureApplicationContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Alma",
                        Chapter = "32",
                        Verse = "21",
                        Note = "And now as I said concerning faith—afaith is not to have a perfect knowledge of things; therefore if ye have faith ye bhope for things which are cnot seen, which are true.And now as I said concerning faith—afaith is not to have a perfect knowledge of things; therefore if ye have faith ye bhope for things which are cnot seen, which are true.",
                        Date_Added = DateTime.Parse("2018-2-12"),
                    },

                    new Scripture
                    {
                        Book = "3 Nephi",
                        Chapter = "11",
                        Verse = "7",
                        Note = "Behold my aBeloved Son, bin whom I am well pleased, in whom I have glorified my name—hear ye him.",
                        Date_Added = DateTime.Parse("2018-3-12"),
                    },

                    new Scripture
                    {
                        Book = "1 Nephi",
                        Chapter = "3",
                        Verse = "7",
                        Note = "And it came to pass that I, Nephi, said unto my father: I awill go and do the things which the Lord hath commanded, for I know that the Lord giveth no bcommandments unto the children of men, save he shall cprepare a way for them that they may accomplish the thing which he commandeth them.",
                        Date_Added = DateTime.Parse("2018-2-24"),
                    },

                    new Scripture
                    {
                        Book = "Ether",
                        Chapter = "12",
                        Verse = "4",
                        Note = "4 Wherefore, whoso believeth in God might with asurety bhope for a better world, yea, even a place at the right hand of God, which chope cometh of dfaith, maketh an eanchor to the souls of men, which would make them sure and steadfast, always abounding in fgood works, being led to gglorify God.",
                        Date_Added = DateTime.Parse("2018-5-17"),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
