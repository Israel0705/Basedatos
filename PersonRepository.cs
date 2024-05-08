using Basedatos.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basedatos
{
    public class PersonRepository
    {
        private string _dbPath;
        private SQLiteConnection conn;

        public string? StatusMessage { get; set; }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Persona>();
        }

        public void AddNewPerson(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre es requerido");

                var person = new Persona { Name = name };
                conn.Insert(person);
                StatusMessage = $"Se insertó una persona {name}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error no insertó una persona {ex.Message}";
            }
        }

        public void DeletePerson(int personId)
        {
            try
            {
                var person = conn.Get<Persona>(personId);
                if (person == null)
                {
                    StatusMessage = $"No se encontró una persona con el ID {personId}";
                    return;
                }

                conn.Delete(person);
                StatusMessage = $"Se eliminó la persona con ID {personId}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error al eliminar la persona: {ex.Message}";
            }
        }

        public List<Persona> GetAllPeople()
        {
            try
            {
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error al obtener las personas: {ex.Message}";
                return new List<Persona>();
            }
        }

        public void UpdatePerson(Persona person)
        {
            try
            {
                conn.Update(person);
                StatusMessage = $"Se actualizó la persona con ID {person.Id}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error al eliminar la persona: {ex.Message}";
            }
        }
    }
}