CREATE DATABASE IF NOT EXISTS healthcare_db;
USE healthcare_db;

CREATE TABLE patients (
    patient_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255),
    date_of_birth DATE,
    gender VARCHAR(50),
    address TEXT
);

CREATE TABLE doctors (
    doctor_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255),
    specialization VARCHAR(255)
);

CREATE TABLE appointments (
    appointment_id INT AUTO_INCREMENT PRIMARY KEY,
    patient_id INT,
    doctor_id INT,
    appointment_date DATE,
    reason TEXT,
    FOREIGN KEY (patient_id) REFERENCES patients(patient_id),
    FOREIGN KEY (doctor_id) REFERENCES doctors(doctor_id)
);

CREATE TABLE medical_records (
    record_id INT AUTO_INCREMENT PRIMARY KEY,
    patient_id INT,
    visit_date DATE,
    diagnosis TEXT,
    treatment TEXT,
    FOREIGN KEY (patient_id) REFERENCES patients(patient_id)
);
INSERT INTO patients (name, date_of_birth, gender, address) VALUES
('Jane Smith 1', '1971-01-02', 'Female', '123 Main St, City 1'),
('Alice Johnson 2', '1972-01-03', 'Other', '123 Main St, City 2'),
('Bob Brown 3', '1973-01-04', 'Male', '123 Main St, City 3'),
('Charlie Davis 4', '1974-01-05', 'Female', '123 Main St, City 4'),
('John Doe 5', '1975-01-06', 'Other', '123 Main St, City 5'),
('Jane Smith 6', '1976-01-07', 'Male', '123 Main St, City 6'),
('Alice Johnson 7', '1977-01-08', 'Female', '123 Main St, City 7'),
('Bob Brown 8', '1978-01-09', 'Other', '123 Main St, City 8'),
('Charlie Davis 9', '1979-01-10', 'Male', '123 Main St, City 9'),
('John Doe 10', '1980-01-11', 'Female', '123 Main St, City 10'),
('Jane Smith 11', '1981-01-12', 'Other', '123 Main St, City 11'),
('Alice Johnson 12', '1982-01-13', 'Male', '123 Main St, City 12'),
('Bob Brown 13', '1983-01-14', 'Female', '123 Main St, City 13'),
('Charlie Davis 14', '1984-01-15', 'Other', '123 Main St, City 14'),
('John Doe 15', '1985-01-16', 'Male', '123 Main St, City 15'),
('Jane Smith 16', '1986-01-17', 'Female', '123 Main St, City 16'),
('Alice Johnson 17', '1987-01-18', 'Other', '123 Main St, City 17'),
('Bob Brown 18', '1988-01-19', 'Male', '123 Main St, City 18'),
('Charlie Davis 19', '1989-01-20', 'Female', '123 Main St, City 19'),
('John Doe 20', '1990-01-21', 'Other', '123 Main St, City 20'),
('Jane Smith 21', '1991-01-22', 'Male', '123 Main St, City 21'),
('Alice Johnson 22', '1992-01-23', 'Female', '123 Main St, City 22'),
('Bob Brown 23', '1993-01-24', 'Other', '123 Main St, City 23'),
('Charlie Davis 24', '1994-01-25', 'Male', '123 Main St, City 24'),
('John Doe 25', '1995-01-26', 'Female', '123 Main St, City 25'),
('Jane Smith 26', '1996-01-27', 'Other', '123 Main St, City 26'),
('Alice Johnson 27', '1997-01-28', 'Male', '123 Main St, City 27'),
('Bob Brown 28', '1998-01-01', 'Female', '123 Main St, City 28'),
('Charlie Davis 29', '1999-01-02', 'Other', '123 Main St, City 29'),
('John Doe 30', '1970-01-03', 'Male', '123 Main St, City 30');

INSERT INTO doctors (name, specialization) VALUES
('Luna Brown 1', 'Neurology'),
('Oscar Green 2', 'Pediatrics'),
('Ivy White 3', 'General Medicine'),
('Max Blue 4', 'Orthopedics'),
('Sam Wilson 5', 'Cardiology'),
('Luna Brown 6', 'Neurology'),
('Oscar Green 7', 'Pediatrics'),
('Ivy White 8', 'General Medicine'),
('Max Blue 9', 'Orthopedics'),
('Sam Wilson 10', 'Cardiology');

INSERT INTO appointments (patient_id, doctor_id, appointment_date, reason) VALUES
(2, 2, '2023-01-02', 'Consultation'),
(3, 3, '2023-01-03', 'Follow-up'),
(4, 4, '2023-01-04', 'Emergency'),
(5, 5, '2023-01-05', 'Specialist visit'),
(6, 6, '2023-01-06', 'Routine check-up'),
(7, 7, '2023-01-07', 'Consultation'),
(8, 8, '2023-01-08', 'Follow-up'),
(9, 9, '2023-01-09', 'Emergency'),
(10, 10, '2023-01-10', 'Specialist visit'),
(11, 1, '2023-01-11', 'Routine check-up'),
(12, 2, '2023-01-12', 'Consultation'),
(13, 3, '2023-01-13', 'Follow-up'),
(14, 4, '2023-01-14', 'Emergency'),
(15, 5, '2023-01-15', 'Specialist visit'),
(16, 6, '2023-01-16', 'Routine check-up'),
(17, 7, '2023-01-17', 'Consultation'),
(18, 8, '2023-01-18', 'Follow-up'),
(19, 9, '2023-01-19', 'Emergency'),
(20, 10, '2023-01-20', 'Specialist visit'),
(21, 1, '2023-01-21', 'Routine check-up'),
(22, 2, '2023-01-22', 'Consultation'),
(23, 3, '2023-01-23', 'Follow-up'),
(24, 4, '2023-01-24', 'Emergency'),
(25, 5, '2023-01-25', 'Specialist visit'),
(26, 6, '2023-01-26', 'Routine check-up'),
(27, 7, '2023-01-27', 'Consultation'),
(28, 8, '2023-01-28', 'Follow-up'),
(29, 9, '2023-01-29', 'Emergency'),
(30, 10, '2023-01-30', 'Specialist visit'),
(1, 1, '2023-01-01', 'Routine check-up'),
(2, 2, '2023-01-02', 'Consultation'),
(3, 3, '2023-01-03', 'Follow-up'),
(4, 4, '2023-01-04', 'Emergency'),
(5, 5, '2023-01-05', 'Specialist visit'),
(6, 6, '2023-01-06', 'Routine check-up'),
(7, 7, '2023-01-07', 'Consultation'),
(8, 8, '2023-01-08', 'Follow-up'),
(9, 9, '2023-01-09', 'Emergency'),
(10, 10, '2023-01-10', 'Specialist visit'),
(11, 1, '2023-01-11', 'Routine check-up'),
(12, 2, '2023-01-12', 'Consultation'),
(13, 3, '2023-01-13', 'Follow-up'),
(14, 4, '2023-01-14', 'Emergency'),
(15, 5, '2023-01-15', 'Specialist visit'),
(16, 6, '2023-01-16', 'Routine check-up'),
(17, 7, '2023-01-17', 'Consultation'),
(18, 8, '2023-01-18', 'Follow-up'),
(19, 9, '2023-01-19', 'Emergency'),
(20, 10, '2023-01-20', 'Specialist visit'),
(21, 1, '2023-01-21', 'Routine check-up'),
(22, 2, '2023-01-22', 'Consultation'),
(23, 3, '2023-01-23', 'Follow-up'),
(24, 4, '2023-01-24', 'Emergency'),
(25, 5, '2023-01-25', 'Specialist visit'),
(26, 6, '2023-01-26', 'Routine check-up'),
(27, 7, '2023-01-27', 'Consultation'),
(28, 8, '2023-01-28', 'Follow-up'),
(29, 9, '2023-01-29', 'Emergency'),
(30, 10, '2023-01-30', 'Specialist visit'),
(1, 1, '2023-01-01', 'Routine check-up');

INSERT INTO medical_records (patient_id, visit_date, diagnosis, treatment) VALUES
(2, '2023-02-02', 'Flu', 'Flu shots'),
(3, '2023-02-03', 'Sprained ankle', 'Ankle brace'),
(4, '2023-02-04', 'Migraine', 'Pain relief medication'),
(5, '2023-02-05', 'Allergies', 'Allergy medication'),
(6, '2023-02-06', 'Common cold', 'Rest and hydration'),
(7, '2023-02-07', 'Flu', 'Flu shots'),
(8, '2023-02-08', 'Sprained ankle', 'Ankle brace'),
(9, '2023-02-09', 'Migraine', 'Pain relief medication'),
(10, '2023-02-10', 'Allergies', 'Allergy medication'),
(11, '2023-02-11', 'Common cold', 'Rest and hydration'),
(12, '2023-02-12', 'Flu', 'Flu shots'),
(13, '2023-02-13', 'Sprained ankle', 'Ankle brace'),
(14, '2023-02-14', 'Migraine', 'Pain relief medication'),
(15, '2023-02-15', 'Allergies', 'Allergy medication'),
(16, '2023-02-16', 'Common cold', 'Rest and hydration'),
(17, '2023-02-17', 'Flu', 'Flu shots'),
(18, '2023-02-18', 'Sprained ankle', 'Ankle brace'),
(19, '2023-02-19', 'Migraine', 'Pain relief medication'),
(20, '2023-02-20', 'Allergies', 'Allergy medication'),
(21, '2023-02-21', 'Common cold', 'Rest and hydration'),
(22, '2023-02-22', 'Flu', 'Flu shots'),
(23, '2023-02-23', 'Sprained ankle', 'Ankle brace'),
(24, '2023-02-24', 'Migraine', 'Pain relief medication'),
(25, '2023-02-25', 'Allergies', 'Allergy medication'),
(26, '2023-02-26', 'Common cold', 'Rest and hydration'),
(27, '2023-02-27', 'Flu', 'Flu shots'),
(28, '2023-02-28', 'Sprained ankle', 'Ankle brace'),
(29, '2023-02-01', 'Migraine', 'Pain relief medication'),
(30, '2023-02-02', 'Allergies', 'Allergy medication'),
(1, '2023-02-03', 'Common cold', 'Rest and hydration'),
(2, '2023-02-04', 'Flu', 'Flu shots'),
(3, '2023-02-05', 'Sprained ankle', 'Ankle brace'),
(4, '2023-02-06', 'Migraine', 'Pain relief medication'),
(5, '2023-02-07', 'Allergies', 'Allergy medication'),
(6, '2023-02-08', 'Common cold', 'Rest and hydration'),
(7, '2023-02-09', 'Flu', 'Flu shots'),
(8, '2023-02-10', 'Sprained ankle', 'Ankle brace'),
(9, '2023-02-11', 'Migraine', 'Pain relief medication'),
(10, '2023-02-12', 'Allergies', 'Allergy medication'),
(11, '2023-02-13', 'Common cold', 'Rest and hydration'),
(12, '2023-02-14', 'Flu', 'Flu shots'),
(13, '2023-02-15', 'Sprained ankle', 'Ankle brace'),
(14, '2023-02-16', 'Migraine', 'Pain relief medication'),
(15, '2023-02-17', 'Allergies', 'Allergy medication'),
(16, '2023-02-18', 'Common cold', 'Rest and hydration'),
(17, '2023-02-19', 'Flu', 'Flu shots'),
(18, '2023-02-20', 'Sprained ankle', 'Ankle brace'),
(19, '2023-02-21', 'Migraine', 'Pain relief medication'),
(20, '2023-02-22', 'Allergies', 'Allergy medication'),
(21, '2023-02-23', 'Common cold', 'Rest and hydration'),
(22, '2023-02-24', 'Flu', 'Flu shots'),
(23, '2023-02-25', 'Sprained ankle', 'Ankle brace'),
(24, '2023-02-26', 'Migraine', 'Pain relief medication'),
(25, '2023-02-27', 'Allergies', 'Allergy medication'),
(26, '2023-02-28', 'Common cold', 'Rest and hydration'),
(27, '2023-02-01', 'Flu', 'Flu shots'),
(28, '2023-02-02', 'Sprained ankle', 'Ankle brace'),
(29, '2023-02-03', 'Migraine', 'Pain relief medication'),
(30, '2023-02-04', 'Allergies', 'Allergy medication'),
(1, '2023-02-05', 'Common cold', 'Rest and hydration');