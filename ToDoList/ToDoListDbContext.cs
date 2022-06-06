using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ToDoList.MVVM.Model;

namespace ToDoList
{
    internal class ToDoListDbContext: DbContext
    {
        public DbSet<PatientModel> PatientTable { get; set; }
        public DbSet<DoctorModel> DoctorTable { get; set; }
        public DbSet<AppointmentsModel> AppointmentsTable { get; set; }
        public DbSet<PrescriptionModel> PrescriptionTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite($"Filename={Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "ToDoList.sqlite")}");
        }
    }
}
