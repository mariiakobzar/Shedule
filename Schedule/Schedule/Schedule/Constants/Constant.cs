using Schedule.Enums;
using Schedule.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Schedule.Constants
{
    public static class Constant
    {

        public static readonly string DbFilePath =
        Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Database.db"
        );

        public static IEnumerable<ExerciseType> DefaultTypes
        {
            get
            {
                var list = new List<ExerciseType>()
                {
                    new ExerciseType(){TypeName = Enums.ExerciseTypeEnum.Грудь.ToString(), TypeColor = Color.FromHex("a3a948")},
                    new ExerciseType(){TypeName = Enums.ExerciseTypeEnum.Бицепс.ToString(), TypeColor = Color.FromHex("EDB92E")},
                    new ExerciseType(){TypeName = Enums.ExerciseTypeEnum.Спина.ToString(), TypeColor = Color.FromHex("F85931")},
                    new ExerciseType(){TypeName = Enums.ExerciseTypeEnum.Ноги.ToString(), TypeColor = Color.FromHex("ce1836")},
                    new ExerciseType(){TypeName = Enums.ExerciseTypeEnum.Плечи.ToString(), TypeColor = Color.FromHex("009989")},
                    new ExerciseType(){TypeName = Enums.ExerciseTypeEnum.Трицепс.ToString(), TypeColor = Color.FromHex("973d97")},
                    new ExerciseType(){TypeName = Enums.ExerciseTypeEnum.Пресс.ToString(), TypeColor = Color.FromHex("009ddc")},
                    new ExerciseType(){TypeName = Enums.ExerciseTypeEnum.Кардио.ToString(), TypeColor = Color.FromHex("3d973d")},
                    new ExerciseType(){TypeName = Enums.ExerciseTypeEnum.Другое.ToString(), TypeColor = Color.FromHex("3d3d97")},
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
                    new Exercise (){ Name = "Жим штанги лежа", Type = ExerciseTypeEnum.Грудь.ToString(),  Color = Color.Purple},
                    new Exercise (){ Name = "Жим гантелей лежа", Type = ExerciseTypeEnum.Грудь.ToString()},
                    new Exercise (){ Name = "Пуловер со штангой", Type = ExerciseTypeEnum.Грудь.ToString()},
                    new Exercise (){ Name = "Отжимания", Type = ExerciseTypeEnum.Грудь.ToString()},
                    new Exercise (){ Name = "Разведения гантелей", Type = ExerciseTypeEnum.Грудь.ToString()},
                    new Exercise (){ Name = "Кроссовер", Type = ExerciseTypeEnum.Грудь.ToString()},

                    new Exercise (){ Name = "Подъём штанги на бицепс", Type = ExerciseTypeEnum.Бицепс.ToString()},
                    new Exercise (){ Name = "Подъём гантелей на бицепс сидя", Type = ExerciseTypeEnum.Бицепс.ToString()},
                    new Exercise (){ Name = "Подъём гантелей на бицепс стоя", Type = ExerciseTypeEnum.Бицепс.ToString()},
                    new Exercise (){ Name = "Молотки", Type = ExerciseTypeEnum.Бицепс.ToString()},
                    new Exercise (){ Name = "Сгибание рук на блоке", Type = ExerciseTypeEnum.Бицепс.ToString()},


                    new Exercise (){ Name = "Тяга Т-грифа широким хватом", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Тяга Т-грифа узким хватом", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Тяга Т-грифа за голову", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Подтягивания средним хватом", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Подтягивания широким хватом", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Горизонтальная тяга", Type = ExerciseTypeEnum.Спина.ToString()},
                    new Exercise (){ Name = "Гиперэкстензия", Type = ExerciseTypeEnum.Спина.ToString()},

                    new Exercise (){ Name = "Становая тяга", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Румынская тяга", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Жим платформы ногами", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Приседания со штангой", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Выпады со штангой", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Выпады с гантелями", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Сведение ног", Type = ExerciseTypeEnum.Ноги.ToString()},
                    new Exercise (){ Name = "Разведение ног", Type = ExerciseTypeEnum.Ноги.ToString()},

                    new Exercise (){ Name = "Армейский жим", Type = ExerciseTypeEnum.Плечи.ToString()},
                    new Exercise (){ Name = "Жим гантелей", Type = ExerciseTypeEnum.Плечи.ToString()},
                    new Exercise (){ Name = "Махи гантелей", Type = ExerciseTypeEnum.Плечи.ToString()},
                    new Exercise (){ Name = "Подъем штанги перед собой", Type = ExerciseTypeEnum.Плечи.ToString()},

                    new Exercise (){ Name = "Жим штанги узким хватом", Type = ExerciseTypeEnum.Трицепс.ToString()},
                    new Exercise (){ Name = "Брусья на трицепс", Type = ExerciseTypeEnum.Трицепс.ToString()},
                    new Exercise (){ Name = "Французкий жим лежа", Type = ExerciseTypeEnum.Трицепс.ToString()},

                    new Exercise (){ Name = "Скручивания", Type = ExerciseTypeEnum.Пресс.ToString()},
                    new Exercise (){ Name = "Подъемы ног лежа", Type = ExerciseTypeEnum.Пресс.ToString()},
                    new Exercise (){ Name = "Подъемы ног в висе", Type = ExerciseTypeEnum.Пресс.ToString()},
                    new Exercise (){ Name = "Планка", Type = ExerciseTypeEnum.Пресс.ToString()},
                    new Exercise (){ Name = "Боковая планка", Type = ExerciseTypeEnum.Пресс.ToString()},
                    new Exercise (){ Name = "Наклоны в сторону с гантелями", Type = ExerciseTypeEnum.Пресс.ToString()},

                    new Exercise (){ Name = "Велосипед", Type = ExerciseTypeEnum.Кардио.ToString()},
                    new Exercise (){ Name = "Беговая дорожка", Type = ExerciseTypeEnum.Кардио.ToString()},
                    new Exercise (){ Name = "Степпер", Type = ExerciseTypeEnum.Кардио.ToString()},

                    new Exercise (){ Name = "Икры - Подъем на носки стоя", Type = ExerciseTypeEnum.Другое.ToString()},
                    new Exercise (){ Name = "Предплечье - Сгибание кистей со штангой", Type = ExerciseTypeEnum.Другое.ToString()},
                    new Exercise (){ Name = "Трапеция - Шаги с гантелями", Type = ExerciseTypeEnum.Другое.ToString()}
                };

                return list.ToList();
            }
        }
    }
}