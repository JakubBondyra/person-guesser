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
                    Name = "Bolesław Chrobry",
                    Count = 1
                },
                new Person()
                {
                    Name = "Mieszko II Lambert",
                    Count = 1
                },
                new Person()
                {
                    Name = "Bolesław Krzywousty",
                    Count = 1
                },
                new Person()
                {
                    Name = "Władysław Łokietek",
                    Count = 1
                },
                new Person()
                {
                    Name = "Kazimierz Wielki",
                    Count = 1
                },
                new Person()
                {
                    Name = "Ludwik Andegaweńczyk",
                    Count = 1
                },
                new Person()
                {
                    Name = "Jadwiga Andegaweńska",
                    Count = 1
                },
                new Person()
                {
                    Name = "Władysław II Jagiełło",
                    Count = 1
                },
                new Person()
                {
                    Name = "Władysław III Warneńczyk",
                    Count = 1
                },
                new Person()
                {
                    Name = "Kazimierz IV Jagiellończyk",
                    Count = 1
                },
                new Person()
                {
                    Name = "Jan I Olbracht",
                    Count = 1
                },
                new Person()
                {
                    Name = "Aleksander II Jagiellończyk",
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
                    Name = "Władysław IV Waza",
                    Count = 1
                },
                new Person()
                {
                    Name = "Jan II Kazimierz",
                    Count = 1
                },
                new Person()
                {
                    Name = "Michał Korybut Wiśniowiecki",
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
                    Name = "Stanisław Leszczyński",
                    Count = 1
                },
                new Person()
                {
                    Name = "Stanisław August Poniatowski",
                    Count = 1
                },
                new Person()
                {
                    Name = "Lech Wałęsa",
                    Count = 1
                },
                new Person()
                {
                    Name = "Ignacy Mościcki",
                    Count = 1
                },
                new Person()
                {
                    Name = "Aleksander Kwaśniewski",
                    Count = 1
                },
                new Person()
                {
                    Name = "Bronisław Komorowski",
                    Count = 1
                },
                new Person()
                {
                    Name = "Andrzej Duda",
                    Count = 1
                },
                new Person()
                {
                    Name = "Lech Kaczyński",
                    Count = 1
                }
            };

            var questions = new[]
            {
                new Question()
                {
                    Text = "Czy był ostatnim królem Polski?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy pochodził z dynastii Jagiellończyków?"
                },
                new Question()
                {
                    Text = "Czy pochodził z dynastii Piastów?"
                },
                new Question()
                {
                    Text = "Czy był królem elekcyjnym?"
                },
                new Question()
                {
                    Text = "Czy był mężczyzną?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy jako król rządził dłużej niż 5 lat?"
                },
                new Question()
                {
                    Text = "Czy żył w XIV wieku?"
                },
                new Question()
                {
                    Text = "Czy żył w XVII wieku?"
                },
                new Question()
                {
                    Text = "Czy zginął śmiercią tragiczną?"
                },
                new Question()
                {
                    Text = "Czy był prezydentem?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy nadal żyje?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy jest obecnym prezydentem?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy ma obecnie więcej niż 60 lat?"
                },
                new Question()
                {
                    Text = "Czy wiadomo, że lubił wypić?"
                },
                new Question()
                {
                    Text = "Czy żył już przed II wojną światową?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy był koronowany?"
                },
                new Question()
                {
                    Text = "Czy za jego czasu panował chaos w państwie?"
                },
                new Question()
                {
                    Text = "Czy za jego czasów podzielono kraj (rozbiory, rozbicie dzielnicowe)?"
                },
                new Question()
                {
                    Text = "Czy na nim zakończyła się dynastia?"
                },
                new Question()
                {
                    Text = "Czy wygrał jakąś bardzo ważną bitwę?"
                },
                new Question()
                {
                    Text = "Czy pochodził z obcej dynastii?"
                },
                new Question()
                {
                    Text = "Czy przeniósł stolicę Polski?"
                }
            };


            //22 pytania
            //dla kazdej osoby dodaj answer dla tego pytania i z odpowiedzią nie (5x)
            //potem pododawaj dla dobrych osób dobre odpowiedzi
            var answers = new List<Answer>();
            var question = questions.Single(x => x.Text == "Czy przeniósł stolicę Polski?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Władysław Łokietek");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();
            //
            question = questions.Single(x => x.Text == "Czy pochodził z obcej dynastii?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Władysław IV Waza");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Ludwik Andegaweńczyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jadwiga Andegaweńska");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy wygrał jakąś bardzo ważną bitwę?");
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


            specifiedPerson = answers.Single(x => x.Person.Name == "Władysław II Jagiełło");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan III Sobieski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy na nim zakończyła się dynastia?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Bolesław Krzywousty");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Mieszko II Lambert");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Mościcki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy za jego czasu panował chaos w państwie?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanisław Leszczyński");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanisław August Poniatowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy był koronowany?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wałęsa");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Mościcki");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaśniewski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczyński");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronisław Komorowski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy żył już przed II wojną światową?");
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
            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wałęsa");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczyński");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaśniewski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronisław Komorowski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy wiadomo, że lubił wypić?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaśniewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy ma obecnie więcej niż 60 lat?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaśniewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronisław Komorowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wałęsa");
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

            question = questions.Single(x => x.Text == "Czy nadal żyje?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaśniewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronisław Komorowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wałęsa");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy był prezydentem?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaśniewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronisław Komorowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wałęsa");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Mościcki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy zginął śmiercią tragiczną?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczyński");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Władysław III Warneńczyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy żył w XVII wieku?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Władysław IV Waza");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Michał Korybut Wiśniowiecki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy żył w XIV wieku?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Władysław II Jagiełło");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Władysław III Warneńczyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Kazimierz IV Jagiellończyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan I Olbracht");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy jako król rządził dłużej niż 5 lat?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Michał Korybut Wiśniowiecki");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Henryk III Walezy");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander II Jagiellończyk");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wałęsa");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Mościcki");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwaśniewski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczyński");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronisław Komorowski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy był mężczyzną?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Jadwiga Andegaweńska");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy był królem elekcyjnym?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Władysław IV Waza");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Michał Korybut Wiśniowiecki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "August III Sas");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanisław Leszczyński");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanisław August Poniatowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy pochodził z dynastii Jagiellończyków?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Władysław II Jagiełło");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Władysław III Warneńczyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Kazimierz IV Jagiellończyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan I Olbracht");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander II Jagiellończyk");
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

            question = questions.Single(x => x.Text == "Czy pochodził z dynastii Piastów?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Bolesław Krzywousty");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bolesław Chrobry");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Władysław Łokietek");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Kazimierz Wielki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy był ostatnim królem Polski?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanisław August Poniatowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            context.SaveChanges();
        }
    }
}
