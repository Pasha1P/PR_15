//погудин павел 
//практическая работа №15
using System;
using System.Collections.Generic;
class Program
{
    struct Patient
    {
        public string lastName;//фамилия
        public string initials;//инициалы
        public int yearOfBirth;//год рождения
        public string gender;//пол
        public string diagnosis;//диагноз
        public string Doctor;//доктор
    }
    static void Patients_Doctor_massiv(Patient[] patients)
    {
        var doctorPatientCounts = new Dictionary<string, int>();
        foreach (var patient in patients)
        {
            if (doctorPatientCounts.ContainsKey(patient.Doctor))
            {
                doctorPatientCounts[patient.Doctor]++;
            }
            else
            {
                doctorPatientCounts[patient.Doctor] = 1;
            }
        }
        // Выводим количество пациентов для каждого лечащего врача
        foreach (var doctor in doctorPatientCounts)
        {
            Console.WriteLine("\t" + doctor.Key + ": " + doctor.Value + " пациентов");
        }
    }
    static void Patients_Diagnosis(Patient[] patients, string diagnosis)
    {
        bool hasPatientsWithDiagnosis = false;
        foreach (var patient in patients)
        {
            if (patient.diagnosis == diagnosis)
            {
                Console.WriteLine("\tФамилия, инициалы: " + patient.lastName);
                Console.WriteLine("\tГод рождения: " + patient.yearOfBirth);
                Console.WriteLine("\tПол: " + patient.gender);
                Console.WriteLine("\tДиагноз: " + patient.diagnosis);
                Console.WriteLine("\tЛечащий врач: " + patient.Doctor);
                Console.WriteLine();
                hasPatientsWithDiagnosis = true;
            }
        }
        if (!hasPatientsWithDiagnosis)
        {
            Console.WriteLine("Пациенты с диагнозом \"" + diagnosis + "\" не найдены");
        }
    }
    static void Print_Statistics(Patient[] patients)
    {
        int totalPatients = patients.Length;
        // Статистика по полу
        var genderCounts = new Dictionary<string, int>();
        foreach (var patient in patients)
        {
            if (genderCounts.ContainsKey(patient.gender))
            {
                genderCounts[patient.gender]++;
            }
            else
            {
                genderCounts[patient.gender] = 1;
            }
        }
        Console.WriteLine("Пол:");
        foreach (var gender in genderCounts)
        {
            double percentage = (double)gender.Value / totalPatients * 100;
            Console.WriteLine(gender.Key + ": " + percentage.ToString("F2") + "%");
        }
        Console.WriteLine();
        // Статистика по диагнозу
        var diagnosisCounts = new Dictionary<string, int>();
        foreach (var patient in patients)
        {
            if (diagnosisCounts.ContainsKey(patient.diagnosis))
            {
                diagnosisCounts[patient.diagnosis]++;
            }
        }
    }
    static void write()
    {
        try
        {
            Console.Write("Введите количество пациентов: ");
            int n = int.Parse(Console.ReadLine());
            Patient[] patients = new Patient[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Пациент №" + (i + 1));
                Console.Write("Фамилия, инициалы: ");
                patients[i].lastName = Console.ReadLine();
                Console.Write("Год рождения: ");
                patients[i].yearOfBirth = int.Parse(Console.ReadLine());
                Console.Write("Пол: ");
                patients[i].gender = Console.ReadLine();
                Console.Write("Диагноз: ");
                patients[i].diagnosis = Console.ReadLine();
                Console.Write("Лечащий врач: ");
                patients[i].Doctor = Console.ReadLine();
                Console.WriteLine();
            }
            // Вывод количества пациентов для каждого лечащего врача
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Количество пациентов для каждого лечащего врача:");
            Patients_Doctor_massiv(patients);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            // Вывод информации о пациентах с определенным диагнозом
            Console.Write("Введите диагноз: ");
            string searchDiagnosis = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tПациенты с диагнозом \"" + searchDiagnosis + "\":");
            Patients_Diagnosis(patients, searchDiagnosis);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            // Вывод статистики по пациентам в процентах
            Console.WriteLine("Статистика по пациентам в процентах:");
            Console.ForegroundColor = ConsoleColor.Green;
            Print_Statistics(patients);
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch
        {
        }
    }
    static void Main(string[] args)
    {
        bool stop =  false;
        while (!stop)
        {
            write();
            Console.Write("если хотите закончить нажмите Enter ");
            string a = Console.ReadLine();
            if (a == "") stop = true;
        }
    }
}

/*ввод
 * 3
 * 1
 * 1
 * 1
 * 1
 * 1
 * 2
 * 2
 * 2
 * 2
 * 2
 * 3
 * 3
 * 1
 * 2
 * 3
 * ответ
 * 1:1
 * 2:1
 * 3:1
 * ввод
 * 3
 * ответ
 * Пациенты с диагнозом "3" не найдены
 * 1: 66,67%
 * 2: 33,33%
 * ввод
 * Enter(кнопка)
 */