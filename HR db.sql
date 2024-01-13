CREATE DATABASE IF NOT EXISTS hr_db;
USE hr_db;

CREATE TABLE departments (
    department_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255)
);

CREATE TABLE employees (
    employee_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255),
    position VARCHAR(255),
    department_id INT,
    hire_date DATE,
    salary DECIMAL(10, 2),
    FOREIGN KEY (department_id) REFERENCES departments(department_id)
);

CREATE TABLE performance_reviews (
    review_id INT AUTO_INCREMENT PRIMARY KEY,
    employee_id INT,
    review_date DATE,
    comments TEXT,
    FOREIGN KEY (employee_id) REFERENCES employees(employee_id)
);

-- department dummy data 
insert into departments (department_id, name) values (1, 'Accounting');
insert into departments (department_id, name) values (2, 'Human Resources');
insert into departments (department_id, name) values (3, 'Services');
insert into departments (department_id, name) values (4, 'Business Development');
insert into departments (department_id, name) values (5, 'Marketing');
insert into departments (department_id, name) values (6, 'Human Resources');
insert into departments (department_id, name) values (7, 'Human Resources');
insert into departments (department_id, name) values (8, 'Legal');
insert into departments (department_id, name) values (9, 'Training');
insert into departments (department_id, name) values (10, 'Accounting');
insert into departments (department_id, name) values (11, 'Accounting');
insert into departments (department_id, name) values (12, 'Business Development');
insert into departments (department_id, name) values (13, 'Accounting');
insert into departments (department_id, name) values (14, 'Legal');
insert into departments (department_id, name) values (15, 'Training');

-- employees db
INSERT INTO employees (name, position, department_id, hire_date, salary) VALUES
('Jane Smith 1', 'Developer', 2, '2019-01-01', 51000.00),
('Alice Johnson 2', 'Analyst', 3, '2019-01-01', 52000.00),
('Bob Brown 3', 'Designer', 4, '2019-01-01', 53000.00),
('Charlie Davis 4', 'Technician', 5, '2019-01-01', 54000.00),
('Emily Evans 5', 'Manager', 6, '2019-01-01', 55000.00),
('Frank Green 6', 'Developer', 7, '2019-01-01', 56000.00),
('Grace Hall 7', 'Analyst', 8, '2019-01-01', 57000.00),
('Henry Irvine 8', 'Designer', 9, '2019-01-01', 58000.00),
('Isla James 9', 'Technician', 10, '2019-01-01', 59000.00),
('John Doe 10', 'Manager', 11, '2019-01-01', 50000.00),
('Jane Smith 11', 'Developer', 12, '2019-01-01', 51000.00),
('Alice Johnson 12', 'Analyst', 13, '2019-01-01', 52000.00),
('Bob Brown 13', 'Designer', 14, '2020-01-01', 53000.00),
('Charlie Davis 14', 'Technician', 15, '2020-01-01', 54000.00),
('Emily Evans 15', 'Manager', 1, '2020-01-01', 55000.00),
('Frank Green 16', 'Developer', 2, '2020-01-01', 56000.00),
('Grace Hall 17', 'Analyst', 3, '2020-01-01', 57000.00),
('Henry Irvine 18', 'Designer', 4, '2020-01-01', 58000.00),
('Isla James 19', 'Technician', 5, '2020-01-01', 59000.00),
('John Doe 20', 'Manager', 6, '2020-01-01', 50000.00),
('Jane Smith 21', 'Developer', 7, '2020-01-01', 51000.00),
('Alice Johnson 22', 'Analyst', 8, '2020-01-01', 52000.00),
('Bob Brown 23', 'Designer', 9, '2020-01-01', 53000.00),
('Charlie Davis 24', 'Technician', 10, '2020-01-01', 54000.00),
('Emily Evans 25', 'Manager', 11, '2021-01-01', 55000.00),
('Frank Green 26', 'Developer', 12, '2021-01-01', 56000.00),
('Grace Hall 27', 'Analyst', 13, '2021-01-01', 57000.00),
('Henry Irvine 28', 'Designer', 14, '2021-01-01', 58000.00),
('Isla James 29', 'Technician', 15, '2021-01-01', 59000.00),
('John Doe 30', 'Manager', 1, '2021-01-01', 50000.00),
('Jane Smith 31', 'Developer', 2, '2021-01-01', 51000.00),
('Alice Johnson 32', 'Analyst', 3, '2021-01-01', 52000.00),
('Bob Brown 33', 'Designer', 4, '2021-01-01', 53000.00),
('Charlie Davis 34', 'Technician', 5, '2021-01-01', 54000.00),
('Emily Evans 35', 'Manager', 6, '2021-01-01', 55000.00),
('Frank Green 36', 'Developer', 7, '2021-01-01', 56000.00),
('Grace Hall 37', 'Analyst', 8, '2022-01-01', 57000.00),
('Henry Irvine 38', 'Designer', 9, '2022-01-01', 58000.00),
('Isla James 39', 'Technician', 10, '2022-01-01', 59000.00),
('John Doe 40', 'Manager', 11, '2022-01-01', 50000.00),
('Jane Smith 41', 'Developer', 12, '2022-01-01', 51000.00),
('Alice Johnson 42', 'Analyst', 13, '2022-01-01', 52000.00),
('Bob Brown 43', 'Designer', 14, '2022-01-01', 53000.00),
('Charlie Davis 44', 'Technician', 15, '2022-01-01', 54000.00),
('Emily Evans 45', 'Manager', 1, '2022-01-01', 55000.00),
('Frank Green 46', 'Developer', 2, '2022-01-01', 56000.00),
('Grace Hall 47', 'Analyst', 3, '2022-01-01', 57000.00),
('Henry Irvine 48', 'Designer', 4, '2022-01-01', 58000.00),
('Isla James 49', 'Technician', 5, '2023-01-01', 59000.00),
('John Doe 50', 'Manager', 6, '2023-01-01', 50000.00),
('Jane Smith 51', 'Developer', 7, '2023-01-01', 51000.00),
('Alice Johnson 52', 'Analyst', 8, '2023-01-01', 52000.00),
('Bob Brown 53', 'Designer', 9, '2023-01-01', 53000.00),
('Charlie Davis 54', 'Technician', 10, '2023-01-01', 54000.00),
('Emily Evans 55', 'Manager', 11, '2023-01-01', 55000.00),
('Frank Green 56', 'Developer', 12, '2023-01-01', 56000.00),
('Grace Hall 57', 'Analyst', 13, '2023-01-01', 57000.00),
('Henry Irvine 58', 'Designer', 14, '2023-01-01', 58000.00),
('Isla James 59', 'Technician', 15, '2023-01-01', 59000.00),
('John Doe 60', 'Manager', 1, '2023-01-01', 50000.00),
('Jane Smith 61', 'Developer', 2, '2024-01-01', 51000.00),
('Alice Johnson 62', 'Analyst', 3, '2024-01-01', 52000.00),
('Bob Brown 63', 'Designer', 4, '2024-01-01', 53000.00),
('Charlie Davis 64', 'Technician', 5, '2024-01-01', 54000.00),
('Emily Evans 65', 'Manager', 6, '2024-01-01', 55000.00),
('Frank Green 66', 'Developer', 7, '2024-01-01', 56000.00),
('Grace Hall 67', 'Analyst', 8, '2024-01-01', 57000.00),
('Henry Irvine 68', 'Designer', 9, '2024-01-01', 58000.00),
('Isla James 69', 'Technician', 10, '2024-01-01', 59000.00),
('John Doe 70', 'Manager', 11, '2024-01-01', 50000.00),
('Jane Smith 71', 'Developer', 12, '2024-01-01', 51000.00),
('Alice Johnson 72', 'Analyst', 13, '2024-01-01', 52000.00),
('Bob Brown 73', 'Designer', 14, '2025-01-01', 53000.00),
('Charlie Davis 74', 'Technician', 15, '2025-01-01', 54000.00),
('Emily Evans 75', 'Manager', 1, '2025-01-01', 55000.00),
('Frank Green 76', 'Developer', 2, '2025-01-01', 56000.00),
('Grace Hall 77', 'Analyst', 3, '2025-01-01', 57000.00),
('Henry Irvine 78', 'Designer', 4, '2025-01-01', 58000.00),
('Isla James 79', 'Technician', 5, '2025-01-01', 59000.00),
('John Doe 80', 'Manager', 6, '2025-01-01', 50000.00),
('Jane Smith 81', 'Developer', 7, '2025-01-01', 51000.00),
('Alice Johnson 82', 'Analyst', 8, '2025-01-01', 52000.00),
('Bob Brown 83', 'Designer', 9, '2025-01-01', 53000.00),
('Charlie Davis 84', 'Technician', 10, '2025-01-01', 54000.00),
('Emily Evans 85', 'Manager', 11, '2026-01-01', 55000.00),
('Frank Green 86', 'Developer', 12, '2026-01-01', 56000.00),
('Grace Hall 87', 'Analyst', 13, '2026-01-01', 57000.00),
('Henry Irvine 88', 'Designer', 14, '2026-01-01', 58000.00),
('Isla James 89', 'Technician', 15, '2026-01-01', 59000.00),
('John Doe 90', 'Manager', 1, '2026-01-01', 50000.00),
('Jane Smith 91', 'Developer', 2, '2026-01-01', 51000.00),
('Alice Johnson 92', 'Analyst', 3, '2026-01-01', 52000.00),
('Bob Brown 93', 'Designer', 4, '2026-01-01', 53000.00),
('Charlie Davis 94', 'Technician', 5, '2026-01-01', 54000.00),
('Emily Evans 95', 'Manager', 6, '2026-01-01', 55000.00),
('Frank Green 96', 'Developer', 7, '2026-01-01', 56000.00),
('Grace Hall 97', 'Analyst', 8, '2027-01-01', 57000.00),
('Henry Irvine 98', 'Designer', 9, '2027-01-01', 58000.00),
('Isla James 99', 'Technician', 10, '2027-01-01', 59000.00),
('John Doe 100', 'Manager', 11, '2027-01-01', 50000.00);

-- performance review
INSERT INTO performance_reviews (employee_id, review_date, comments) VALUES
(2, '2019-01-01', 'Meets all performance standards.'),
(3, '2019-01-01', 'Needs improvement in specific areas.'),
(4, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(5, '2019-01-01', 'Requires additional training to meet job expectations.'),
(6, '2019-01-01', 'Exceeds expectations in all areas.'),
(7, '2019-01-01', 'Meets all performance standards.'),
(8, '2019-01-01', 'Needs improvement in specific areas.'),
(9, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(10, '2019-01-01', 'Requires additional training to meet job expectations.'),
(11, '2019-01-01', 'Exceeds expectations in all areas.'),
(12, '2019-01-01', 'Meets all performance standards.'),
(13, '2019-01-01', 'Needs improvement in specific areas.'),
(14, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(15, '2019-01-01', 'Requires additional training to meet job expectations.'),
(16, '2019-01-01', 'Exceeds expectations in all areas.'),
(17, '2019-01-01', 'Meets all performance standards.'),
(18, '2019-01-01', 'Needs improvement in specific areas.'),
(19, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(20, '2019-01-01', 'Requires additional training to meet job expectations.'),
(21, '2019-01-01', 'Exceeds expectations in all areas.'),
(22, '2019-01-01', 'Meets all performance standards.'),
(23, '2019-01-01', 'Needs improvement in specific areas.'),
(24, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(25, '2019-01-01', 'Requires additional training to meet job expectations.'),
(26, '2019-01-01', 'Exceeds expectations in all areas.'),
(27, '2019-01-01', 'Meets all performance standards.'),
(28, '2019-01-01', 'Needs improvement in specific areas.'),
(29, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(30, '2019-01-01', 'Requires additional training to meet job expectations.'),
(31, '2019-01-01', 'Exceeds expectations in all areas.'),
(32, '2019-01-01', 'Meets all performance standards.'),
(33, '2019-01-01', 'Needs improvement in specific areas.'),
(34, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(35, '2019-01-01', 'Requires additional training to meet job expectations.'),
(36, '2019-01-01', 'Exceeds expectations in all areas.'),
(37, '2019-01-01', 'Meets all performance standards.'),
(38, '2019-01-01', 'Needs improvement in specific areas.'),
(39, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(40, '2019-01-01', 'Requires additional training to meet job expectations.'),
(41, '2019-01-01', 'Exceeds expectations in all areas.'),
(42, '2019-01-01', 'Meets all performance standards.'),
(43, '2019-01-01', 'Needs improvement in specific areas.'),
(44, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(45, '2019-01-01', 'Requires additional training to meet job expectations.'),
(46, '2019-01-01', 'Exceeds expectations in all areas.'),
(47, '2019-01-01', 'Meets all performance standards.'),
(48, '2019-01-01', 'Needs improvement in specific areas.'),
(49, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(50, '2019-01-01', 'Requires additional training to meet job expectations.'),
(51, '2019-01-01', 'Exceeds expectations in all areas.'),
(52, '2019-01-01', 'Meets all performance standards.'),
(53, '2019-01-01', 'Needs improvement in specific areas.'),
(54, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(55, '2019-01-01', 'Requires additional training to meet job expectations.'),
(56, '2019-01-01', 'Exceeds expectations in all areas.'),
(57, '2019-01-01', 'Meets all performance standards.'),
(58, '2019-01-01', 'Needs improvement in specific areas.'),
(59, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(60, '2019-01-01', 'Requires additional training to meet job expectations.'),
(61, '2019-01-01', 'Exceeds expectations in all areas.'),
(62, '2019-01-01', 'Meets all performance standards.'),
(63, '2019-01-01', 'Needs improvement in specific areas.'),
(64, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(65, '2019-01-01', 'Requires additional training to meet job expectations.'),
(66, '2019-01-01', 'Exceeds expectations in all areas.'),
(67, '2019-01-01', 'Meets all performance standards.'),
(68, '2019-01-01', 'Needs improvement in specific areas.'),
(69, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(70, '2019-01-01', 'Requires additional training to meet job expectations.'),
(71, '2019-01-01', 'Exceeds expectations in all areas.'),
(72, '2019-01-01', 'Meets all performance standards.'),
(73, '2019-01-01', 'Needs improvement in specific areas.'),
(74, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(75, '2019-01-01', 'Requires additional training to meet job expectations.'),
(76, '2019-01-01', 'Exceeds expectations in all areas.'),
(77, '2019-01-01', 'Meets all performance standards.'),
(78, '2019-01-01', 'Needs improvement in specific areas.'),
(79, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(80, '2019-01-01', 'Requires additional training to meet job expectations.'),
(81, '2019-01-01', 'Exceeds expectations in all areas.'),
(82, '2019-01-01', 'Meets all performance standards.'),
(83, '2019-01-01', 'Needs improvement in specific areas.'),
(84, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(85, '2019-01-01', 'Requires additional training to meet job expectations.'),
(86, '2019-01-01', 'Exceeds expectations in all areas.'),
(87, '2019-01-01', 'Meets all performance standards.'),
(88, '2019-01-01', 'Needs improvement in specific areas.'),
(89, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(90, '2019-01-01', 'Requires additional training to meet job expectations.'),
(91, '2019-01-01', 'Exceeds expectations in all areas.'),
(92, '2019-01-01', 'Meets all performance standards.'),
(93, '2019-01-01', 'Needs improvement in specific areas.'),
(94, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(95, '2019-01-01', 'Requires additional training to meet job expectations.'),
(96, '2019-01-01', 'Exceeds expectations in all areas.'),
(97, '2019-01-01', 'Meets all performance standards.'),
(98, '2019-01-01', 'Needs improvement in specific areas.'),
(99, '2019-01-01', 'Demonstrates outstanding performance in team projects.'),
(100, '2019-01-01', 'Requires additional training to meet job expectations.');
INSERT INTO performance_reviews (employee_id, review_date, comments) VALUES
(1, '2019-01-01', 'Exceeds expectations in all areas.'),
(1, '2020-01-01', 'Meets all performance standards.'),
(2, '2019-01-01', 'Exceeds expectations in all areas.'),
(2, '2020-01-01', 'Meets all performance standards.'),
(2, '2021-01-01', 'Needs improvement in specific areas.'),
(3, '2019-01-01', 'Exceeds expectations in all areas.'),
(3, '2020-01-01', 'Meets all performance standards.'),
(3, '2021-01-01', 'Needs improvement in specific areas.'),
(3, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(4, '2019-01-01', 'Exceeds expectations in all areas.'),
(4, '2020-01-01', 'Meets all performance standards.'),
(4, '2021-01-01', 'Needs improvement in specific areas.'),
(4, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(4, '2023-01-01', 'Requires additional training to meet job expectations.'),
(5, '2019-01-01', 'Exceeds expectations in all areas.'),
(6, '2019-01-01', 'Exceeds expectations in all areas.'),
(6, '2020-01-01', 'Meets all performance standards.'),
(7, '2019-01-01', 'Exceeds expectations in all areas.'),
(7, '2020-01-01', 'Meets all performance standards.'),
(7, '2021-01-01', 'Needs improvement in specific areas.'),
(8, '2019-01-01', 'Exceeds expectations in all areas.'),
(8, '2020-01-01', 'Meets all performance standards.'),
(8, '2021-01-01', 'Needs improvement in specific areas.'),
(8, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(9, '2019-01-01', 'Exceeds expectations in all areas.'),
(9, '2020-01-01', 'Meets all performance standards.'),
(9, '2021-01-01', 'Needs improvement in specific areas.'),
(9, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(9, '2023-01-01', 'Requires additional training to meet job expectations.'),
(10, '2019-01-01', 'Exceeds expectations in all areas.'),
(11, '2019-01-01', 'Exceeds expectations in all areas.'),
(11, '2020-01-01', 'Meets all performance standards.'),
(12, '2019-01-01', 'Exceeds expectations in all areas.'),
(12, '2020-01-01', 'Meets all performance standards.'),
(12, '2021-01-01', 'Needs improvement in specific areas.'),
(13, '2019-01-01', 'Exceeds expectations in all areas.'),
(13, '2020-01-01', 'Meets all performance standards.'),
(13, '2021-01-01', 'Needs improvement in specific areas.'),
(13, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(14, '2019-01-01', 'Exceeds expectations in all areas.'),
(14, '2020-01-01', 'Meets all performance standards.'),
(14, '2021-01-01', 'Needs improvement in specific areas.'),
(14, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(14, '2023-01-01', 'Requires additional training to meet job expectations.'),
(15, '2019-01-01', 'Exceeds expectations in all areas.'),
(16, '2019-01-01', 'Exceeds expectations in all areas.'),
(16, '2020-01-01', 'Meets all performance standards.'),
(17, '2019-01-01', 'Exceeds expectations in all areas.'),
(17, '2020-01-01', 'Meets all performance standards.'),
(17, '2021-01-01', 'Needs improvement in specific areas.'),
(18, '2019-01-01', 'Exceeds expectations in all areas.'),
(18, '2020-01-01', 'Meets all performance standards.'),
(18, '2021-01-01', 'Needs improvement in specific areas.'),
(18, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(19, '2019-01-01', 'Exceeds expectations in all areas.'),
(19, '2020-01-01', 'Meets all performance standards.'),
(19, '2021-01-01', 'Needs improvement in specific areas.'),
(19, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(19, '2023-01-01', 'Requires additional training to meet job expectations.'),
(20, '2019-01-01', 'Exceeds expectations in all areas.'),
(21, '2019-01-01', 'Exceeds expectations in all areas.'),
(21, '2020-01-01', 'Meets all performance standards.'),
(22, '2019-01-01', 'Exceeds expectations in all areas.'),
(22, '2020-01-01', 'Meets all performance standards.'),
(22, '2021-01-01', 'Needs improvement in specific areas.'),
(23, '2019-01-01', 'Exceeds expectations in all areas.'),
(23, '2020-01-01', 'Meets all performance standards.'),
(23, '2021-01-01', 'Needs improvement in specific areas.'),
(23, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(24, '2019-01-01', 'Exceeds expectations in all areas.'),
(24, '2020-01-01', 'Meets all performance standards.'),
(24, '2021-01-01', 'Needs improvement in specific areas.'),
(24, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(24, '2023-01-01', 'Requires additional training to meet job expectations.'),
(25, '2019-01-01', 'Exceeds expectations in all areas.'),
(26, '2019-01-01', 'Exceeds expectations in all areas.'),
(26, '2020-01-01', 'Meets all performance standards.'),
(27, '2019-01-01', 'Exceeds expectations in all areas.'),
(27, '2020-01-01', 'Meets all performance standards.'),
(27, '2021-01-01', 'Needs improvement in specific areas.'),
(28, '2019-01-01', 'Exceeds expectations in all areas.'),
(28, '2020-01-01', 'Meets all performance standards.'),
(28, '2021-01-01', 'Needs improvement in specific areas.'),
(28, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(29, '2019-01-01', 'Exceeds expectations in all areas.'),
(29, '2020-01-01', 'Meets all performance standards.'),
(29, '2021-01-01', 'Needs improvement in specific areas.'),
(29, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(29, '2023-01-01', 'Requires additional training to meet job expectations.'),
(30, '2019-01-01', 'Exceeds expectations in all areas.'),
(31, '2019-01-01', 'Exceeds expectations in all areas.'),
(31, '2020-01-01', 'Meets all performance standards.'),
(32, '2019-01-01', 'Exceeds expectations in all areas.'),
(32, '2020-01-01', 'Meets all performance standards.'),
(32, '2021-01-01', 'Needs improvement in specific areas.'),
(33, '2019-01-01', 'Exceeds expectations in all areas.'),
(33, '2020-01-01', 'Meets all performance standards.'),
(33, '2021-01-01', 'Needs improvement in specific areas.'),
(33, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(34, '2019-01-01', 'Exceeds expectations in all areas.'),
(34, '2020-01-01', 'Meets all performance standards.'),
(34, '2021-01-01', 'Needs improvement in specific areas.'),
(34, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(34, '2023-01-01', 'Requires additional training to meet job expectations.'),
(35, '2019-01-01', 'Exceeds expectations in all areas.'),
(36, '2019-01-01', 'Exceeds expectations in all areas.'),
(36, '2020-01-01', 'Meets all performance standards.'),
(37, '2019-01-01', 'Exceeds expectations in all areas.'),
(37, '2020-01-01', 'Meets all performance standards.'),
(37, '2021-01-01', 'Needs improvement in specific areas.'),
(38, '2019-01-01', 'Exceeds expectations in all areas.'),
(38, '2020-01-01', 'Meets all performance standards.'),
(38, '2021-01-01', 'Needs improvement in specific areas.'),
(38, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(39, '2019-01-01', 'Exceeds expectations in all areas.'),
(39, '2020-01-01', 'Meets all performance standards.'),
(39, '2021-01-01', 'Needs improvement in specific areas.'),
(39, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(39, '2023-01-01', 'Requires additional training to meet job expectations.'),
(40, '2019-01-01', 'Exceeds expectations in all areas.'),
(41, '2019-01-01', 'Exceeds expectations in all areas.'),
(41, '2020-01-01', 'Meets all performance standards.'),
(42, '2019-01-01', 'Exceeds expectations in all areas.'),
(42, '2020-01-01', 'Meets all performance standards.'),
(42, '2021-01-01', 'Needs improvement in specific areas.'),
(43, '2019-01-01', 'Exceeds expectations in all areas.'),
(43, '2020-01-01', 'Meets all performance standards.'),
(43, '2021-01-01', 'Needs improvement in specific areas.'),
(43, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(44, '2019-01-01', 'Exceeds expectations in all areas.'),
(44, '2020-01-01', 'Meets all performance standards.'),
(44, '2021-01-01', 'Needs improvement in specific areas.'),
(44, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(44, '2023-01-01', 'Requires additional training to meet job expectations.'),
(45, '2019-01-01', 'Exceeds expectations in all areas.'),
(46, '2019-01-01', 'Exceeds expectations in all areas.'),
(46, '2020-01-01', 'Meets all performance standards.'),
(47, '2019-01-01', 'Exceeds expectations in all areas.'),
(47, '2020-01-01', 'Meets all performance standards.'),
(47, '2021-01-01', 'Needs improvement in specific areas.'),
(48, '2019-01-01', 'Exceeds expectations in all areas.'),
(48, '2020-01-01', 'Meets all performance standards.'),
(48, '2021-01-01', 'Needs improvement in specific areas.'),
(48, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(49, '2019-01-01', 'Exceeds expectations in all areas.'),
(49, '2020-01-01', 'Meets all performance standards.'),
(49, '2021-01-01', 'Needs improvement in specific areas.'),
(49, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(49, '2023-01-01', 'Requires additional training to meet job expectations.'),
(50, '2019-01-01', 'Exceeds expectations in all areas.'),
(51, '2019-01-01', 'Exceeds expectations in all areas.'),
(51, '2020-01-01', 'Meets all performance standards.'),
(52, '2019-01-01', 'Exceeds expectations in all areas.'),
(52, '2020-01-01', 'Meets all performance standards.'),
(52, '2021-01-01', 'Needs improvement in specific areas.'),
(53, '2019-01-01', 'Exceeds expectations in all areas.'),
(53, '2020-01-01', 'Meets all performance standards.'),
(53, '2021-01-01', 'Needs improvement in specific areas.'),
(53, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(54, '2019-01-01', 'Exceeds expectations in all areas.'),
(54, '2020-01-01', 'Meets all performance standards.'),
(54, '2021-01-01', 'Needs improvement in specific areas.'),
(54, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(54, '2023-01-01', 'Requires additional training to meet job expectations.'),
(55, '2019-01-01', 'Exceeds expectations in all areas.'),
(56, '2019-01-01', 'Exceeds expectations in all areas.'),
(56, '2020-01-01', 'Meets all performance standards.'),
(57, '2019-01-01', 'Exceeds expectations in all areas.'),
(57, '2020-01-01', 'Meets all performance standards.'),
(57, '2021-01-01', 'Needs improvement in specific areas.'),
(58, '2019-01-01', 'Exceeds expectations in all areas.'),
(58, '2020-01-01', 'Meets all performance standards.'),
(58, '2021-01-01', 'Needs improvement in specific areas.'),
(58, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(59, '2019-01-01', 'Exceeds expectations in all areas.'),
(59, '2020-01-01', 'Meets all performance standards.'),
(59, '2021-01-01', 'Needs improvement in specific areas.'),
(59, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(59, '2023-01-01', 'Requires additional training to meet job expectations.'),
(60, '2019-01-01', 'Exceeds expectations in all areas.'),
(61, '2019-01-01', 'Exceeds expectations in all areas.'),
(61, '2020-01-01', 'Meets all performance standards.'),
(62, '2019-01-01', 'Exceeds expectations in all areas.'),
(62, '2020-01-01', 'Meets all performance standards.'),
(62, '2021-01-01', 'Needs improvement in specific areas.'),
(63, '2019-01-01', 'Exceeds expectations in all areas.'),
(63, '2020-01-01', 'Meets all performance standards.'),
(63, '2021-01-01', 'Needs improvement in specific areas.'),
(63, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(64, '2019-01-01', 'Exceeds expectations in all areas.'),
(64, '2020-01-01', 'Meets all performance standards.'),
(64, '2021-01-01', 'Needs improvement in specific areas.'),
(64, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(64, '2023-01-01', 'Requires additional training to meet job expectations.'),
(65, '2019-01-01', 'Exceeds expectations in all areas.'),
(66, '2019-01-01', 'Exceeds expectations in all areas.'),
(66, '2020-01-01', 'Meets all performance standards.'),
(67, '2019-01-01', 'Exceeds expectations in all areas.'),
(67, '2020-01-01', 'Meets all performance standards.'),
(67, '2021-01-01', 'Needs improvement in specific areas.'),
(68, '2019-01-01', 'Exceeds expectations in all areas.'),
(68, '2020-01-01', 'Meets all performance standards.'),
(68, '2021-01-01', 'Needs improvement in specific areas.'),
(68, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(69, '2019-01-01', 'Exceeds expectations in all areas.'),
(69, '2020-01-01', 'Meets all performance standards.'),
(69, '2021-01-01', 'Needs improvement in specific areas.'),
(69, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(69, '2023-01-01', 'Requires additional training to meet job expectations.'),
(70, '2019-01-01', 'Exceeds expectations in all areas.'),
(71, '2019-01-01', 'Exceeds expectations in all areas.'),
(71, '2020-01-01', 'Meets all performance standards.'),
(72, '2019-01-01', 'Exceeds expectations in all areas.'),
(72, '2020-01-01', 'Meets all performance standards.'),
(72, '2021-01-01', 'Needs improvement in specific areas.'),
(73, '2019-01-01', 'Exceeds expectations in all areas.'),
(73, '2020-01-01', 'Meets all performance standards.'),
(73, '2021-01-01', 'Needs improvement in specific areas.'),
(73, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(74, '2019-01-01', 'Exceeds expectations in all areas.'),
(74, '2020-01-01', 'Meets all performance standards.'),
(74, '2021-01-01', 'Needs improvement in specific areas.'),
(74, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(74, '2023-01-01', 'Requires additional training to meet job expectations.'),
(75, '2019-01-01', 'Exceeds expectations in all areas.'),
(76, '2019-01-01', 'Exceeds expectations in all areas.'),
(76, '2020-01-01', 'Meets all performance standards.'),
(77, '2019-01-01', 'Exceeds expectations in all areas.'),
(77, '2020-01-01', 'Meets all performance standards.'),
(77, '2021-01-01', 'Needs improvement in specific areas.'),
(78, '2019-01-01', 'Exceeds expectations in all areas.'),
(78, '2020-01-01', 'Meets all performance standards.'),
(78, '2021-01-01', 'Needs improvement in specific areas.'),
(78, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(79, '2019-01-01', 'Exceeds expectations in all areas.'),
(79, '2020-01-01', 'Meets all performance standards.'),
(79, '2021-01-01', 'Needs improvement in specific areas.'),
(79, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(79, '2023-01-01', 'Requires additional training to meet job expectations.'),
(80, '2019-01-01', 'Exceeds expectations in all areas.'),
(81, '2019-01-01', 'Exceeds expectations in all areas.'),
(81, '2020-01-01', 'Meets all performance standards.'),
(82, '2019-01-01', 'Exceeds expectations in all areas.'),
(82, '2020-01-01', 'Meets all performance standards.'),
(82, '2021-01-01', 'Needs improvement in specific areas.'),
(83, '2019-01-01', 'Exceeds expectations in all areas.'),
(83, '2020-01-01', 'Meets all performance standards.'),
(83, '2021-01-01', 'Needs improvement in specific areas.'),
(83, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(84, '2019-01-01', 'Exceeds expectations in all areas.'),
(84, '2020-01-01', 'Meets all performance standards.'),
(84, '2021-01-01', 'Needs improvement in specific areas.'),
(84, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(84, '2023-01-01', 'Requires additional training to meet job expectations.'),
(85, '2019-01-01', 'Exceeds expectations in all areas.'),
(86, '2019-01-01', 'Exceeds expectations in all areas.'),
(86, '2020-01-01', 'Meets all performance standards.'),
(87, '2019-01-01', 'Exceeds expectations in all areas.'),
(87, '2020-01-01', 'Meets all performance standards.'),
(87, '2021-01-01', 'Needs improvement in specific areas.'),
(88, '2019-01-01', 'Exceeds expectations in all areas.'),
(88, '2020-01-01', 'Meets all performance standards.'),
(88, '2021-01-01', 'Needs improvement in specific areas.'),
(88, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(89, '2019-01-01', 'Exceeds expectations in all areas.'),
(89, '2020-01-01', 'Meets all performance standards.'),
(89, '2021-01-01', 'Needs improvement in specific areas.'),
(89, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(89, '2023-01-01', 'Requires additional training to meet job expectations.'),
(90, '2019-01-01', 'Exceeds expectations in all areas.'),
(91, '2019-01-01', 'Exceeds expectations in all areas.'),
(91, '2020-01-01', 'Meets all performance standards.'),
(92, '2019-01-01', 'Exceeds expectations in all areas.'),
(92, '2020-01-01', 'Meets all performance standards.'),
(92, '2021-01-01', 'Needs improvement in specific areas.'),
(93, '2019-01-01', 'Exceeds expectations in all areas.'),
(93, '2020-01-01', 'Meets all performance standards.'),
(93, '2021-01-01', 'Needs improvement in specific areas.'),
(93, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(94, '2019-01-01', 'Exceeds expectations in all areas.'),
(94, '2020-01-01', 'Meets all performance standards.'),
(94, '2021-01-01', 'Needs improvement in specific areas.'),
(94, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(94, '2023-01-01', 'Requires additional training to meet job expectations.'),
(95, '2019-01-01', 'Exceeds expectations in all areas.'),
(96, '2019-01-01', 'Exceeds expectations in all areas.'),
(96, '2020-01-01', 'Meets all performance standards.'),
(97, '2019-01-01', 'Exceeds expectations in all areas.'),
(97, '2020-01-01', 'Meets all performance standards.'),
(97, '2021-01-01', 'Needs improvement in specific areas.'),
(98, '2019-01-01', 'Exceeds expectations in all areas.'),
(98, '2020-01-01', 'Meets all performance standards.'),
(98, '2021-01-01', 'Needs improvement in specific areas.'),
(98, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(99, '2019-01-01', 'Exceeds expectations in all areas.'),
(99, '2020-01-01', 'Meets all performance standards.'),
(99, '2021-01-01', 'Needs improvement in specific areas.'),
(99, '2022-01-01', 'Demonstrates outstanding performance in team projects.'),
(99, '2023-01-01', 'Requires additional training to meet job expectations.'),
(100, '2019-01-01', 'Exceeds expectations in all areas.');
