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
                    Name = "Boles�aw Chrobry",
                    Count = 1
                },
                new Person()
                {
                    Name = "Mieszko II Lambert",
                    Count = 1
                },
                new Person()
                {
                    Name = "Boles�aw Krzywousty",
                    Count = 1
                },
                new Person()
                {
                    Name = "W�adys�aw �okietek",
                    Count = 1
                },
                new Person()
                {
                    Name = "Kazimierz Wielki",
                    Count = 1
                },
                new Person()
                {
                    Name = "Ludwik Andegawe�czyk",
                    Count = 1
                },
                new Person()
                {
                    Name = "Jadwiga Andegawe�ska",
                    Count = 1
                },
                new Person()
                {
                    Name = "W�adys�aw II Jagie��o",
                    Count = 1
                },
                new Person()
                {
                    Name = "W�adys�aw III Warne�czyk",
                    Count = 1
                },
                new Person()
                {
                    Name = "Kazimierz IV Jagiello�czyk",
                    Count = 1
                },
                new Person()
                {
                    Name = "Jan I Olbracht",
                    Count = 1
                },
                new Person()
                {
                    Name = "Aleksander II Jagiello�czyk",
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
                    Name = "W�adys�aw IV Waza",
                    Count = 1
                },
                new Person()
                {
                    Name = "Jan II Kazimierz",
                    Count = 1
                },
                new Person()
                {
                    Name = "Micha� Korybut Wi�niowiecki",
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
                    Name = "Stanis�aw Leszczy�ski",
                    Count = 1
                },
                new Person()
                {
                    Name = "Stanis�aw August Poniatowski",
                    Count = 1
                },
                new Person()
                {
                    Name = "Lech Wa��sa",
                    Count = 1
                },
                new Person()
                {
                    Name = "Ignacy Mo�cicki",
                    Count = 1
                },
                new Person()
                {
                    Name = "Aleksander Kwa�niewski",
                    Count = 1
                },
                new Person()
                {
                    Name = "Bronis�aw Komorowski",
                    Count = 1
                },
                new Person()
                {
                    Name = "Andrzej Duda",
                    Count = 1
                },
                new Person()
                {
                    Name = "Lech Kaczy�ski",
                    Count = 1
                }
            };

            var questions = new[]
            {
                new Question()
                {
                    Text = "Czy by� ostatnim kr�lem Polski?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy pochodzi� z dynastii Jagiello�czyk�w?"
                },
                new Question()
                {
                    Text = "Czy pochodzi� z dynastii Piast�w?"
                },
                new Question()
                {
                    Text = "Czy by� kr�lem elekcyjnym?"
                },
                new Question()
                {
                    Text = "Czy by� m�czyzn�?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy jako kr�l rz�dzi� d�u�ej ni� 5 lat?"
                },
                new Question()
                {
                    Text = "Czy �y� w XIV wieku?"
                },
                new Question()
                {
                    Text = "Czy �y� w XVII wieku?"
                },
                new Question()
                {
                    Text = "Czy zgin�� �mierci� tragiczn�?"
                },
                new Question()
                {
                    Text = "Czy by� prezydentem?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy nadal �yje?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy jest obecnym prezydentem?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy ma obecnie wi�cej ni� 60 lat?"
                },
                new Question()
                {
                    Text = "Czy wiadomo, �e lubi� wypi�?"
                },
                new Question()
                {
                    Text = "Czy �y� ju� przed II wojn� �wiatow�?",
                    Unforgiveable = true
                },
                new Question()
                {
                    Text = "Czy by� koronowany?"
                },
                new Question()
                {
                    Text = "Czy za jego czasu panowa� chaos w pa�stwie?"
                },
                new Question()
                {
                    Text = "Czy za jego czas�w podzielono kraj (rozbiory, rozbicie dzielnicowe)?"
                },
                new Question()
                {
                    Text = "Czy na nim zako�czy�a si� dynastia?"
                },
                new Question()
                {
                    Text = "Czy wygra� jak�� bardzo wa�n� bitw�?"
                },
                new Question()
                {
                    Text = "Czy pochodzi� z obcej dynastii?"
                },
                new Question()
                {
                    Text = "Czy przeni�s� stolic� Polski?"
                }
            };


            //22 pytania
            //dla kazdej osoby dodaj answer dla tego pytania i z odpowiedzi� nie (5x)
            //potem pododawaj dla dobrych os�b dobre odpowiedzi
            var answers = new List<Answer>();
            var question = questions.Single(x => x.Text == "Czy przeni�s� stolic� Polski?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "W�adys�aw �okietek");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();
            //
            question = questions.Single(x => x.Text == "Czy pochodzi� z obcej dynastii?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "W�adys�aw IV Waza");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Ludwik Andegawe�czyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jadwiga Andegawe�ska");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy wygra� jak�� bardzo wa�n� bitw�?");
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


            specifiedPerson = answers.Single(x => x.Person.Name == "W�adys�aw II Jagie��o");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan III Sobieski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy na nim zako�czy�a si� dynastia?");
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

            question = questions.Single(x => x.Text == "Czy za jego czas�w podzielono kraj (rozbiory, rozbicie dzielnicowe)?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Boles�aw Krzywousty");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Mieszko II Lambert");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Mo�cicki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy za jego czasu panowa� chaos w pa�stwie?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanis�aw Leszczy�ski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanis�aw August Poniatowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy by� koronowany?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa��sa");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Mo�cicki");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwa�niewski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczy�ski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis�aw Komorowski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy �y� ju� przed II wojn� �wiatow�?");
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
            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa��sa");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczy�ski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwa�niewski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis�aw Komorowski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy wiadomo, �e lubi� wypi�?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwa�niewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy ma obecnie wi�cej ni� 60 lat?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwa�niewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis�aw Komorowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa��sa");
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

            question = questions.Single(x => x.Text == "Czy nadal �yje?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwa�niewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis�aw Komorowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa��sa");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy by� prezydentem?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwa�niewski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis�aw Komorowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa��sa");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Mo�cicki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy zgin�� �mierci� tragiczn�?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczy�ski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W�adys�aw III Warne�czyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy �y� w XVII wieku?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "W�adys�aw IV Waza");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Micha� Korybut Wi�niowiecki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy �y� w XIV wieku?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "W�adys�aw II Jagie��o");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W�adys�aw III Warne�czyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Kazimierz IV Jagiello�czyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan I Olbracht");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy jako kr�l rz�dzi� d�u�ej ni� 5 lat?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Micha� Korybut Wi�niowiecki");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Henryk III Walezy");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander II Jagiello�czyk");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Wa��sa");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Ignacy Mo�cicki");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander Kwa�niewski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Lech Kaczy�ski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Andrzej Duda");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            specifiedPerson = answers.Single(x => x.Person.Name == "Bronis�aw Komorowski");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy by� m�czyzn�?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Jadwiga Andegawe�ska");
            specifiedPerson.NoCount = 5;
            specifiedPerson.YesCount = 0;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy by� kr�lem elekcyjnym?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "W�adys�aw IV Waza");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Micha� Korybut Wi�niowiecki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "August III Sas");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanis�aw Leszczy�ski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanis�aw August Poniatowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy pochodzi� z dynastii Jagiello�czyk�w?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "W�adys�aw II Jagie��o");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W�adys�aw III Warne�czyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Kazimierz IV Jagiello�czyk");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Jan I Olbracht");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Aleksander II Jagiello�czyk");
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

            question = questions.Single(x => x.Text == "Czy pochodzi� z dynastii Piast�w?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Boles�aw Krzywousty");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Boles�aw Chrobry");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "W�adys�aw �okietek");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            specifiedPerson = answers.Single(x => x.Person.Name == "Kazimierz Wielki");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            question = questions.Single(x => x.Text == "Czy by� ostatnim kr�lem Polski?");
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

            specifiedPerson = answers.Single(x => x.Person.Name == "Stanis�aw August Poniatowski");
            specifiedPerson.NoCount = 0;
            specifiedPerson.YesCount = 5;

            context.Answers.AddRange(answers);
            answers.Clear();

            context.SaveChanges();
        }
    }
}
