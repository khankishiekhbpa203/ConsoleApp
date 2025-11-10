using Domain.Entities;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implimentations
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data == null)
                {
                    throw new NotFoundException("Student not found!");
                }
                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Student data)
        {
            try
            {
                if (data==null)
                {
                    throw new NotFoundException("Student doesnt exist");
                }
                AppDbContext<Student>.datas.Remove(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public Student Get(Predicate<Student> predicate)
        {
            try
            {
                var student = AppDbContext<Student>.datas.Find(predicate);

                if (student == null) throw new NotFoundException("Student not found!");

                return student;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Repository error: {ex.Message}");
                throw;
            }
        }

        public List<Student> GetAll(Predicate<Student> predicate)
        {
            try
            {
                List<Student> result = new List<Student>();

                if (predicate == null)
                {
                    for (int i = 0; i < AppDbContext<Student>.datas.Count; i++)
                    {
                        result.Add(AppDbContext<Student>.datas[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < AppDbContext<Student>.datas.Count; i++)
                    {
                        var student = AppDbContext<Student>.datas[i];
                        if (predicate(student))
                        {
                            result.Add(student);
                        }
                    }
                }

                if (result.Count == 0)
                    Console.WriteLine("No students found.");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return new List<Student>();
            }
        }

        public void Update(Student data)
        {
            try
            {
                if (data == null) throw new NullPredicateException("Student cannot be null.");

                bool found = false;

                for (int i = 0; i < AppDbContext<Student>.datas.Count; i++)
                {
                    var existstudent = AppDbContext<Student>.datas[i];

                    if (existstudent.Name == data.Name &&existstudent.Surname == data.Surname)
                    {
                        existstudent.userGroup = data.userGroup;

                        Console.WriteLine($"Student '{existstudent.Name} {existstudent.Surname}' updated successfully.");
                        found = true;
                        break;
                    }
                }

                if (!found) throw new NotFoundException("Student not found");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
            }
        }
    }
}

