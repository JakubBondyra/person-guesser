using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.PgContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.PgContext context)
        {
            //tutaj seed
            var people = new[]
            {
                new Person()
                {
                    Name = "Mieszko I",
                    Count = 1
                },
                new Person()
                {
                    Name = "Boles³aw Chrobry",
                    Count = 1
                },
                new Person()
                {
                    Name = "Mieszko II Lambert",
                    Count = 1
                },
                new Person()
                {
                    Name = "Boles³aw Krzywousty",
                    Count = 1
                },
                new Person()
                {
                    Name = "W³adys³aw £okietek",
                    Count = 1
                },
                new Person()
                {
                    Name = "Kazimierz Wielki",
                    Count = 1
                },
                new Person()
                {
                    Name = "Ludwik Andegaweñczyk",
                    Count = 1
                },
                new Person()
                {
                    Name = "Jadwiga Andegaweñska",
                    Count = 1
                },
                new Person()
                {
                    Name = "W³adys³aw II Jagie³³o",
                    Count = 1
                },
                new Person()
                {
                    Name = "W³adys³aw III Warneñczyk",
                    Count = 1
                },
                new Person()
                {
                    Name = "Kazimierz IV Jagielloñczyk",
                    Count = 1
                },
                new Person()
                {
                    Name = "Jan I Olbracht",
                    Count = 1
                },
                new Person()
                {
                    Name = "Aleksander II Jagielloñczyk",
                    Count = 1
                },
                new Person()
                {
                    Name = "Zygmunt I Stary",
                    Count = 1
                },
                new Person()
                {
                    Name = "Zygmunt II August",
                    Count = 1
                },
                new Person()
                {
                    Name = "Henryk III Walezy",
                    Count = 1
                },
                new Person()
                {
                    Name = "Stefan Batory",
                    Count = 1
                },
                new Person()
                {
                    Name = "Zygmunt III Waza",
                    Count = 1
                },
                new Person()
                {
                    Name = "W³adys³aw IV Waza",
                    Count = 1
                },
                new Person()
                {
                    Name = "Jan II Kazimierz",
                    Count = 1
                },
                new Person()
                {
                    Name = "Micha³ Korybut Wiœniowiecki",
                    Count = 1
                },
                new Person()
                {
                    Name = "Jan III Sobieski",
                    Count = 1
                },
                new Person()
                {
                    Name = "August II Mocny",
                    Count = 1
                },
                new Person()
                {
                    Name = "August III Sas",
                    Count = 1
                },
                new Person()
                {
                    Name = "Stanis³aw Leszczyñski",
                    Count = 1
                },
                new Person()
                {
                    Name = "Stanis³aw August Poniatowski",
                    Count = 1
                },
                new Person()
                {
                    Name = "Lech Wa³êsa",
                    Count = 1
                },
                new Person()
                {
                    Name = "Ignacy Moœcicki",
                    Count = 1
                },
                new Person()
                {
                    Name = "Aleksander Kwaœniewski",
                    Count = 1
                },
                new Person()
                {
                    Name = "Bronis³aw Komorowski",
                    Count = 1
                },
                new Person()
                {
                    Name = "Andrzej Duda",
                    Count = 1
                },
                new Person()
                {
                    Name = "Lech Kaczyñski",
                    Count = 1
                }
            };

            var questions = new[]
            {
                new Question()
                {
                    Text = "Czy by³ ostatnim królem Polski?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy pochodzi³ z dynastii Jagielloñczyków?"
                },
                new Question()
                {
                    Text = "Czy pochodzi³ z dynastii Piastów?"
                },
                new Question()
                {
                    Text = "Czy by³ królem elekcyjnym?"
                },
                new Question()
                {
                    Text = "Czy by³ mê¿czyzn¹?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy jako król rz¹dzi³ d³u¿ej ni¿ 5 lat?"
                },
                new Question()
                {
                    Text = "Czy ¿y³ w XIV wieku?"
                },
                new Question()
                {
                    Text = "Czy ¿y³ w XVII wieku?"
                },
                new Question()
                {
                    Text = "Czy zgin¹³ œmierci¹ tragiczn¹?"
                },
                new Question()
                {
                    Text = "Czy by³ prezydentem?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy nadal ¿yje?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy jest obecnym prezydentem?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy ma obecnie wiêcej ni¿ 60 lat?"
                },
                new Question()
                {
                    Text = "Czy wiadomo, ¿e lubi³ wypiæ?"
                },
                new Question()
                {
                    Text = "Czy ¿y³ ju¿ przed II wojn¹ œwiatow¹?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy by³ koronowany?"
                },
                new Question()
                {
                    Text = "Czy za jego czasu panowa³ chaos w pañstwie?"
                },
                new Question()
                {
                    Text = "Czy za jego czasów podzielono kraj (rozbiory, rozbicie dzielnicowe)?"
                },
                new Question()
                {
                    Text = "Czy na nim zakoñczy³a siê dynastia?"
                },
                new Question()
                {
                    Text = "Czy wygra³ jak¹œ bardzo wa¿n¹ bitwê?"
                },
                new Question()
                {
                    Text = "Czy pochodzi³ z obcej dynastii?"
                },
                new Question()
                {
                    Text = "Czy przeniós³ stolicê Polski?"
                }
            };


            //22 pytania
            //dla kazdej osoby dodaj answer dla tego pytania i z odpowiedzi¹ nie (5x)
            //potem pododawaj dla dobrych osób dobre odpowiedzi
            var answers = new List<Answer>();
            var question = questions.Single(x => x.Text == "Czy przeniós³ stolicê Polski?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }
            var specifiedPerson = answers.Single(x => x.Person.Name == "Zygmunt III Waza");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W³adys³aw £okietek");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();
            //
            question = questions.Single(x => x.Text == "Czy pochodzi³ z obcej dynastii?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }
            specifiedPerson = answers.Single(x => x.Person.Name == "Zygmunt III Waza");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W³adys³aw IV Waza");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Henryk III Walezy");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stefan Batory");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan II Kazimierz");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "August II Mocny");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "August III Sas");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ludwik Andegaweñczyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jadwiga Andegaweñska");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy wygra³ jak¹œ bardzo wa¿n¹ bitwê?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }


            specifiedPerson = answers.Single(x => x.Person.Name == "W³adys³aw II Jagie³³o");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan III Sobieski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy na nim zakoñczy³a siê dynastia?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }
            specifiedPerson = answers.Single(x => x.Person.Name == "Kazimierz Wielki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Zygmunt II August");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy za jego czasów podzielono kraj (rozbiory, rozbicie dzielnicowe)?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }
            specifiedPerson = answers.Single(x => x.Person.Name == "Mieszko II Lambert");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Boles³aw Krzywousty");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Mieszko II Lambert");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Moœcicki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy za jego czasu panowa³ chaos w pañstwie?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }
            specifiedPerson = answers.Single(x => x.Person.Name == "Mieszko II Lambert");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "August II Mocny");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "August III Sas");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanis³aw Leszczyñski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanis³aw August Poniatowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy by³ koronowany?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 0,
                    YesCount = 5
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Mieszko I");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa³êsa");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Moœcicki");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaœniewski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczyñski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis³aw Komorowski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy ¿y³ ju¿ przed II wojn¹ œwiatow¹?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 0,
                    YesCount = 5
                });
            }
            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa³êsa");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczyñski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaœniewski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis³aw Komorowski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy wiadomo, ¿e lubi³ wypiæ?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaœniewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy ma obecnie wiêcej ni¿ 60 lat?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaœniewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis³aw Komorowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa³êsa");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy jest obecnym prezydentem?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy nadal ¿yje?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaœniewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis³aw Komorowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa³êsa");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy by³ prezydentem?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaœniewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis³aw Komorowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa³êsa");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Moœcicki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy zgin¹³ œmierci¹ tragiczn¹?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczyñski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W³adys³aw III Warneñczyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy ¿y³ w XVII wieku?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Zygmunt III Waza");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W³adys³aw IV Waza");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan II Kazimierz");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "August II Mocny");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan III Sobieski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Micha³ Korybut Wiœniowiecki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy ¿y³ w XIV wieku?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "W³adys³aw II Jagie³³o");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W³adys³aw III Warneñczyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Kazimierz IV Jagielloñczyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan I Olbracht");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy jako król rz¹dzi³ d³u¿ej ni¿ 5 lat?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 0,
                    YesCount = 5
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Micha³ Korybut Wiœniowiecki");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Henryk III Walezy");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander II Jagielloñczyk");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa³êsa");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Moœcicki");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaœniewski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczyñski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis³aw Komorowski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy by³ mê¿czyzn¹?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 0,
                    YesCount = 5
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Jadwiga Andegaweñska");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy by³ królem elekcyjnym?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Zygmunt III Waza");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Henryk III Walezy");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stefan Batory");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W³adys³aw IV Waza");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan II Kazimierz");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "August II Mocny");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan III Sobieski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Micha³ Korybut Wiœniowiecki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "August III Sas");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanis³aw Leszczyñski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanis³aw August Poniatowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy pochodzi³ z dynastii Jagielloñczyków?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "W³adys³aw II Jagie³³o");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W³adys³aw III Warneñczyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Kazimierz IV Jagielloñczyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan I Olbracht");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander II Jagielloñczyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Zygmunt I Stary");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Zygmunt II August");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy pochodzi³ z dynastii Piastów?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Mieszko I");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Mieszko II Lambert");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Boles³aw Krzywousty");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Boles³aw Chrobry");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W³adys³aw £okietek");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Kazimierz Wielki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy by³ ostatnim królem Polski?");
            foreach (var person in people)
            {
                answers.Add(new Answer()
                {
                    Person = person,
                    Question = question,
                    NoCount = 5,
                    YesCount = 0
                });
            }

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanis³aw August Poniatowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            context.SaveChanges();
        }
    }
}
