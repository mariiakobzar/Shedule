using Schedule.Enums;
using Schedule.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Schedule.Constants
{
    public static class Constant
    {

        public static readonly string DbFilePath =
        Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "MyDatabase.db"
        );

        public static IEnumerable<ExerciseType> DefaultTypes
        {
            get
            {
                var list = new List<ExerciseType>()
                {
                    new ExerciseType(){Type = ExerciseTypeEnum.Груди ,TypeName = Enums.ExerciseTypeEnum.Груди.ToString(), TypeColor = Color.FromHex("973d97"),
                        ImagePath = "@drawable/chest.png"},
                    new ExerciseType(){Type = ExerciseTypeEnum.Біцепс, TypeName = Enums.ExerciseTypeEnum.Біцепс.ToString(), TypeColor = Color.FromHex("3d973d"),
                        ImagePath = "@drawable/biceps.png"},
                    new ExerciseType(){Type = ExerciseTypeEnum.Спина, TypeName = Enums.ExerciseTypeEnum.Спина.ToString(), TypeColor = Color.FromHex("F85931"),
                        ImagePath ="@drawable/bodybuilder.png"},
                    new ExerciseType(){Type = ExerciseTypeEnum.Ноги, TypeName = Enums.ExerciseTypeEnum.Ноги.ToString(), TypeColor = Color.FromHex("ce1836"),
                        ImagePath = "@drawable/leg.png"},
                    new ExerciseType(){Type = ExerciseTypeEnum.Плечі, TypeName = Enums.ExerciseTypeEnum.Плечі.ToString(), TypeColor = Color.FromHex("009989"),
                        ImagePath = "@drawable/shoulders.png"},
                    new ExerciseType(){Type = ExerciseTypeEnum.Трицепс, TypeName = Enums.ExerciseTypeEnum.Трицепс.ToString(), TypeColor = Color.FromHex("a3a948"),
                        ImagePath = "@drawable/triceps.png"},
                    new ExerciseType(){Type = ExerciseTypeEnum.Прес, TypeName = Enums.ExerciseTypeEnum.Прес.ToString(), TypeColor = Color.FromHex("009ddc"),
                        ImagePath = "@drawable/prelum.png"},
                    new ExerciseType(){Type = ExerciseTypeEnum.Кардіо, TypeName = Enums.ExerciseTypeEnum.Кардіо.ToString(), TypeColor = Color.FromHex("C71585"),
                        ImagePath = "@drawable/pilates.png"},
                    new ExerciseType(){Type = ExerciseTypeEnum.Інше, TypeName = Enums.ExerciseTypeEnum.Інше.ToString(), TypeColor = Color.FromHex("3d3d97"),
                        ImagePath = "@drawable/yoga.png"},
                };

                return list.ToList();
            }
        }

        public static IEnumerable<Exercise> DefaultExercises
        {
            get
            {
                var list = new List<Exercise>()
                {
                    new Exercise (){ Name = "Жим штанги лежачи", Type = ExerciseTypeEnum.Груди.ToString()},
                    new Exercise (){ Name = "Жим гантелей лежачи", Type = ExerciseTypeEnum.Груди.ToString()},
                    new Exercise (){ Name = "Пуловер зі штангою", Type = ExerciseTypeEnum.Груди.ToString()},
                    new Exercise (){ Name = "Віджимання", Type = ExerciseTypeEnum.Груди.ToString()},
                    new Exercise (){ Name = "Розведення гантелей", Type = ExerciseTypeEnum.Груди.ToString()},
                    new Exercise (){ Name = "Кросовер", Type = ExerciseTypeEnum.Груди.ToString()},

                    new Exercise (){ Name = "Підйом штанги", Type = ExerciseTypeEnum.Біцепс.ToString()},
                    new Exercise (){ Name = "Підйом гантелей сидячи", Type = ExerciseTypeEnum.Біцепс.ToString()},
                    new Exercise (){ Name = "Підйом гантелей стоячи", Type = ExerciseTypeEnum.Біцепс.ToString()},
                    new Exercise (){ Name = "Молотки", Type = ExerciseTypeEnum.Біцепс.ToString()},
                    new Exercise (){ Name = "Згинання рук на блоці", Type = ExerciseTypeEnum.Біцепс.ToString()},


                    new Exercise (){ Name = "Тяга Т-грифа широким хватом", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Тяга Т-грифа вузьким хватом", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Тяга Т-грифа за голову", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Підтягування середнім хватом", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Підтягування широким хватом", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Горизонтальная тяга", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Гіперекстензія", Type = ExerciseTypeEnum.Спина.ToString()},

                    new Exercise (){ Name = "Станова тяга", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Румунська тяга", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Жим платформи ногами", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Присідання зі штангою", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Випади зі штангою", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Випади з гантелями", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Зведення ніг", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Розведення ніг", Type = ExerciseTypeEnum.Ноги.ToString()},

                    new Exercise (){ Name = "Армійський жим", Type = ExerciseTypeEnum.Плечі.ToString()},
                    new Exercise (){ Name = "Жим гантелей", Type = ExerciseTypeEnum.Плечі.ToString()},
                    new Exercise (){ Name = "Махи гантелей", Type = ExerciseTypeEnum.Плечі.ToString()},
                    new Exercise (){ Name = "Підйом штанги перед собою", Type = ExerciseTypeEnum.Плечі.ToString()},
                    
                    new Exercise (){ Name = "Жим штанги вузьким хватом", Type = ExerciseTypeEnum.Трицепс.ToString()},
                    new Exercise (){ Name = "Бруси на трицепс", Type = ExerciseTypeEnum.Трицепс.ToString()},
                    new Exercise (){ Name = "Французький жим лежачи", Type = ExerciseTypeEnum.Трицепс.ToString()},

                    new Exercise (){ Name = "Скручування", Type = ExerciseTypeEnum.Прес.ToString()},
                    new Exercise (){ Name = "Підйоми ніг лежачи", Type = ExerciseTypeEnum.Прес.ToString()},
                    new Exercise (){ Name = "Підйоми ніг у висі", Type = ExerciseTypeEnum.Прес.ToString()},
                    new Exercise (){ Name = "Планка", Type = ExerciseTypeEnum.Прес.ToString()},
                    new Exercise (){ Name = "Бокова планка", Type = ExerciseTypeEnum.Прес.ToString()},
                    new Exercise (){ Name = "Нахили в бік з гантелями", Type = ExerciseTypeEnum.Прес.ToString()},

                    new Exercise (){ Name = "Велосипед", Type = ExerciseTypeEnum.Кардіо.ToString()},
                    new Exercise (){ Name = "Бігова доріжка", Type = ExerciseTypeEnum.Кардіо.ToString()},
                    new Exercise (){ Name = "Степпер", Type = ExerciseTypeEnum.Кардіо.ToString()},

                    new Exercise (){ Name = "Ікри - Підйом на шкарпетки", Type = ExerciseTypeEnum.Інше.ToString()},
                    new Exercise (){ Name = "Передпліччя - Згинання кистей", Type = ExerciseTypeEnum.Інше.ToString()},
                    new Exercise (){ Name = "Трапеція - Підйом з гантелями", Type = ExerciseTypeEnum.Інше.ToString()}
                };

                foreach (var item in list)
                {
                    if (item.Type == "Груди")
                    {
                        item.ImagePath = "@drawable/chest.png";
                    }
                    else if (item.Type == "Біцепс")
                    {
                        item.ImagePath = "@drawable/biceps.png";
                    }
                    ///////////////////////////
                    else if (item.Type == "Спина")
                    {
                        item.ImagePath = "@drawable/bodybuilder.png";
                    }
                    else if (item.Type == "Ноги")
                    {
                        item.ImagePath = "@drawable/leg.png";
                    }
                    else if (item.Type == "Плечі")
                    {
                        item.ImagePath = "@drawable/shoulders.png";
                    }
                    else if (item.Type == "Трицепс")
                    {
                        item.ImagePath = "@drawable/triceps.png";
                    }
                    else if (item.Type == "Прес")
                    {
                        item.ImagePath = "@drawable/prelum.png";
                    }
                    ///////////////////////////
                    else if (item.Type == "Кардіо")
                    {
                        item.ImagePath = "@drawable/pilates.png";
                    }
                    else if (item.Type == "Інше")
                    {
                        item.ImagePath = "@drawable/yoga.png";
                    }
                }

                return list.ToList();
            }
        }

        public static string GetHexString(Color color)
        {
            var red = (int)(color.R * 255);
            var green = (int)(color.G * 255);
            var blue = (int)(color.B * 255);
            var alpha = (int)(color.A * 255);
            var hex = $"#{alpha:X2}{red:X2}{green:X2}{blue:X2}";

            return hex;
        }
    }
}