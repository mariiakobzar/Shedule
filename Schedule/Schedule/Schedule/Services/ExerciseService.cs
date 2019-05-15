﻿using Schedule.Constants;
using Schedule.Interfaces;
using Schedule.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schedule.Services
{
    public class ExerciseService : IDataBaseService<Exercise>
    {
        private static SQLiteConnection db = null;
        private static bool isInitialized = false;

        static ExerciseService()
        {
            var dbPath = Constant.DbFilePath;
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Exercise>();
            db.DeleteAll<Exercise>();
        }

        public ExerciseService()
        {
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            if (!isInitialized)
            {
                db.InsertAll(Constant.DefaultExercises);
                isInitialized = true;
            }
        }

        public IEnumerable<Exercise> GetAllInstances()
        {
            var table = db.Table<Exercise>();
            foreach (var x in table)
            {
                yield return x;
            }
        }

        public IEnumerable<Exercise> GetInstances(int id)
        {
            var table = db.Table<Exercise>().Where(x => x.Id == id);
            foreach (var x in table)
            {
                yield return x;
            }
        }

        public IEnumerable<Exercise> GetInstancesByDate(int date)
        {
            var table = db.Table<Exercise>().Where(x => x.DateId == date);
            foreach (var x in table)
            {
                yield return x;
            }
        }

        public Exercise GetInstance(int id)
        {
            var table = db.Table<Exercise>();
            return table.Where(p => p.Id == id).FirstOrDefault();
        }

        public void CreateInstance(Exercise exercise)
        {
            db.Insert(exercise);
        }

        public void UpdateInstance(Exercise exercise)
        {
            db.Update(exercise);
        }

        public void InsertInstance(Exercise exercise)
        {
            db.Insert(exercise);
        }

        public void DeleteInstance(Exercise exercise)
        {
            db.Delete(exercise);
        }

        public Exercise FindInstance(int id)
        {
            var table = db.Table<Exercise>().ToList();
            return table.Where(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateTable()
        {
            var table = db.Table<Exercise>();
            db.UpdateAll(table);
        }

        public void ClearTable()
        {
            db.DeleteAll<Exercise>();
        }
    }
}