-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Mar 19, 2016 at 07:43 AM
-- Server version: 10.1.8-MariaDB
-- PHP Version: 5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ccs_db`
--
CREATE DATABASE IF NOT EXISTS `ccs_db` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `ccs_db`;

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `username` varchar(10) DEFAULT NULL,
  `password` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`username`, `password`) VALUES
('user', 'EAAAAARlZVsxSozKfWs+qMQpoxUIyQIQj4lImEOmelIFqDpv');

-- --------------------------------------------------------

--
-- Table structure for table `assessment`
--

CREATE TABLE `assessment` (
  `assessment_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `duration` varchar(8) DEFAULT NULL,
  `date_taken` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `career`
--

CREATE TABLE `career` (
  `career_id` int(11) NOT NULL,
  `career_name` varchar(70) DEFAULT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `career`
--

INSERT INTO `career` (`career_id`, `career_name`, `description`) VALUES
(1, 'Technology Careers', 'Recommended Student Classes: Take math and computer classes.\r\n\r\nExample Careers: Software Developer, Information Security Analyst, Database Administrator, Web Developer, Programmer$ Network Computer Systems Administrator, Computer Support.\r\n\r\nCareer Growth: According to the BLS, advances in technology are fueling the growth of multiple industries. For example, advances in technology is a contributor of growth in the healthcare field, the demand for smart phones and wireless technology is contributing to growth in the electronic manufacturing industry, and consulting services are growing so businesses can keep pace with new technologies. To meet this demand, there is a need for those in the information technology (IT) field.'),
(2, 'Culinary Careers', 'Recommended Student Classes: Take math and business classes.\r\n\r\nExample Careers: Dietician, Chef, Baker, Food Service, Lodging Manager.\r\n\r\nCareer Growth: The food service and hospitality industries are projected to continue growing. However, wages in food service are some of the lowest. Positions requiring an education pay the most, but those positions have lower occupational growth rates.'),
(3, 'Business Careers', 'Recommended Student Classes: Take writing, public speaking, math, and business classes.\r\n\r\nExample Careers: Market Research Analyst, Financial Advisor, Logistician (Supply Chain Management), Human Resources, Public Relations, Accountant, Secretary.\r\n\r\nCareer Growth: The business services sector is expected to add 3.5 million jobs by 2022and is the third-fastest among other service sectors. According to the BLS, by 2022 the health care, social assistance, and professional and business services sectors are expected to account for more than a quarter of all jobs.'),
(4, 'Education & Training Careers', 'Recommended Student Classes: Take courses in the subject you want to teach as well as public speaking, computer, and writing classes. \r\n\r\nExample Careers: Teacher, Guidance Counselor, Librarian, Tutor/Teacher''s Aid. \r\n\r\nCareer Growth: The education sector is expected to see the second-fastest growth among the service sectors according to the BLS. Enrollment of students in primary, secondary, and post-secondary schools continue to rise.'),
(5, 'Health Science Careers', 'Recommended Student Classes: Anatomy, biology, chemistry, math, and physics courses. \r\n\r\nExample Careers: Sonographer (Ultrasound), Registered Nurse (RN), Certified Nursing Assistant (CNA), Licensed Practical Nurse (LPN), Radiographer (X-Ray Techn), Surgical Technologist $↑, Dental Assistant/Dental Hygienist, Physical Therapist (PT), PT Assistant, Occupational Therapist (OT), OT Assistant, Speech Therapist, Doctor/Surgeon, Emergency Medical Technician (EMT), Medical Office/Record Assistant (transcriptionist), Clinical Lab Tech, Veterinarian.\r\n\r\nCareer Growth: Most of the top 20 highest paid careers are in the health care field and most of the fastest growing jobs are also in the medical field. The BLS identifies an aging population, advances in technology, and cost-cutting measures such as out-patient services becoming more in-demand than in-patient services as contibuting factors.'),
(6, 'Language & Communication Careers', 'Recommended Student Classes: Writing, public speaking, computer classes, psychology, and sociology will be beneficial. \r\n\r\nExample Careers: English, Foreign Language, or Literature Teacher, Technical Writer and Editor, Interpreter/Translator, Public Relations, Marketing and Advertising .'),
(7, 'Math & Engineering Careers', 'Recommended Student Classes: Rigorous math, science, and computer courses are the most valued.\r\n\r\nExample Careers: Actuary, Engineer (most), Software Developer, Financial Advisor, Economist, Statistician, Accountant.\r\n\r\nCareer Growth: The financial industry is expected to see the largest growth in service-providing sectors according to the BLS. Contributing factors include people reaching retirement age and those seeking retirement planning services.'),
(8, 'Natural Science Careers', 'Recommended Student Classes: Take rigorous science courses.\r\n\r\nExample Careers: Geographer, Anthropologist, Archeologist, Oceanographer $↑, Biochemist, Biophysist, Geoscientist, Marine Biologist, Chemist.'),
(9, 'Law & Public Safety Careers', 'Recommended Student Classes: Learn a second langauge and take public speaking.\r\n\r\nExample Careers: Paralegal, Forensics (Crime Scene Investigation), Law Enforcement, Correctional Officers, Firefighters, Lawyer, Security Guard, Wildlife Officer.'),
(10, 'Social Science Careers', 'Recommended Student Classes: Psychology, sociology, and human relations are beneficial courses to take for a career in the social sciences.\r\n\r\nExample Careers: Social Science Teacher, Social Worker, Psychologist, Sociologist.'),
(11, 'Art Careers', 'Recommended Student Classes: Writing, public speaking, and art courses are important. Start creating a portfolio or your work. \r\n\r\nExample Visual Art Careers: Interior Designer, Graphic Designer, Industrial Designer, Photographer, Fashion Designer, Fine Artists, Model/Actor, Makeup Artist or Cosmetologist (hair stylist)'),
(12, 'Wellness & Athletic Careers', 'Recommended Student Classes: Courses related to nutrition, health education, physical education, human biology, and psychology are helpful. \r\n\r\nExample Careers: Physical Therapist (health field), Nutritionist or Dietitian (health field), Personal Training (health field), Law Enforcement, Firefighter, Homeland Security, Recreational Therapist, Military.'),
(13, 'Multimedia Careers', 'Recommended Student Classes: Take computer, art, public speaking, and writing classes. \r\n\r\n Example Careers: Web Developer, Multimedia Artist and Animator, Industrial Designer $, Photographer, Graphic Designer, Recording Arts (sound/music), Producer or Director, Video Editor/Camera Operator.');

-- --------------------------------------------------------

--
-- Table structure for table `conversation`
--

CREATE TABLE `conversation` (
  `conversation_id` int(11) NOT NULL,
  `assessment_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `counselor_id` int(11) DEFAULT NULL,
  `date_added` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `counselor`
--

CREATE TABLE `counselor` (
  `counselor_id` int(11) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `password` text,
  `fullname` varchar(60) DEFAULT NULL,
  `specialization` varchar(200) DEFAULT NULL,
  `date_added` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `counselor_message`
--

CREATE TABLE `counselor_message` (
  `message_id` int(11) NOT NULL,
  `conversation_id` int(11) NOT NULL,
  `content` text,
  `read` tinyint(1) DEFAULT NULL,
  `date_time_sent` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `interest`
--

CREATE TABLE `interest` (
  `interest_id` int(11) NOT NULL,
  `interest_name` varchar(70) DEFAULT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `interest`
--

INSERT INTO `interest` (`interest_id`, `interest_name`, `description`) VALUES
(1, 'Technology', 'Example Careers: Network/Security Admin, Computer Programmer, Digital Media Artist, Computer Forensics, Cryptanalyst, Robotics, Computer Support Specialist, Engineer, Game Design/Development.\r\n\r\nCareer Growth: The Computer Systems Design and Related Services industry is the fifth fastest-growing industry according to the BLS with an annual rate of growth of 3.2%. Technical consulting services and the software publishers industry are also fast-growing industries.'),
(2, 'Outdoors & Physical', 'Example Careers: The BLS lists jobs by both desk time and overall activity. Among these more active jobs are quite a few which offer generous salaries and solid occupational outlook. Listed are active jobs that earn more than $50,000 a year: Police Officer, Construction and Building Inspector, Rotary Drill Operators (Oil and Gas), Elevator Installer/Repair, and Electrical Power-Line Installer/Repair. Though indoors, many workers in the health field are on their feet and not behind a desk. Radiation Therapists, Occupational Therapists (and Assistants), Physician Assistants, Registered Nurses, Nurse Practitioners, Veterinarians, and Physical Therapists are just a few to consider. The following careers may or may not pay $50,000 a year, but also fit this category: Farmers, or Greenhouse Workers, Forest and Conservation Workers, Loggers, Animal Trainers, Firefighters, Military Personnel, Environmental Scientists, Archeologists, Surveyors, and Landscape Architects.'),
(3, 'Helping People', 'Example Careers: Social Worker, Therapist (various), Medical Positions, Counselor, Teacher, Spiritual Leader, Firefighter, Law Enforcement. \r\n\r\nCareer Growth: The healthcare field is booming with high salaries and growth rate. According to the BLS, the individual and family services industry is also expected to have the second-fastest growth in employment. This industry provides social services to children, elderly people, people with disabilities, and others. Another sector that is growing is nursing and residential care facilities. This would include helping people who live in assisted living communities or nursing homes. Helping those with rehabilitation and personal care are also fast growing.'),
(4, 'Fixing & Building', 'Example Careers: Construction, Mechanic, Structural Iron and Steel Worker, Carpentry, Upholstery, Electrician, Equipment Install and Repair, Plumber, Production Worker.\r\n\r\nCareer Growth: Construction is projected to be one of the fastest growing industries. The BLS states the reason for this growth is investiment in residential and nonresidential structures. As residential homes become older, there will be a demand for newer homes. A growing populatin also adds to this demand.');

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `question_id` int(11) NOT NULL,
  `question` text,
  `career_id` int(11) DEFAULT NULL,
  `interest_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`question_id`, `question`, `career_id`, `interest_id`) VALUES
(1, 'Maintain, install, or repair computers.', 1, NULL),
(2, 'Try new food recipes.', 2, NULL),
(3, 'Help a business or client meet financial goals.', 3, NULL),
(4, 'Teach people new skills.', 4, NULL),
(5, 'Take care of people, even strangers.', 5, NULL),
(6, 'Write books, articles, essays, or plays.', 6, NULL),
(7, 'Interpret data/numbers and problem solve.', 7, NULL),
(8, 'Discover why and how chemicals react to one another.', 8, NULL),
(9, 'Investigate crimes.', 9, NULL),
(10, 'Learn about human relations and psychology.', 10, NULL),
(11, 'Design a costume or stage set.', 11, NULL),
(12, 'Motivate, encourage, and help others to fulfill their goals.', 12, NULL),
(13, 'Animate graphics on a computer.', 13, NULL),
(14, 'Learn computer software programs.', 1, NULL),
(15, 'Learn what fruits and vegetables are in season.', 2, NULL),
(16, 'Learn how to start a business', 3, NULL),
(17, 'Train employees.', 4, NULL),
(18, 'Learn how the body functions.', 5, NULL),
(19, 'Research and create reports.', 6, NULL),
(20, 'Design airplanes, buildings, bridges, or machinery.', 7, NULL),
(21, 'Study marine life in their habitat.', 8, NULL),
(22, 'Serve your community and keep it safe.', 9, NULL),
(23, 'Understand world events and politics.', 10, NULL),
(24, 'Critique art, music, or performances.', 11, NULL),
(25, 'Train people to meet fitness goals.', 12, NULL),
(26, 'Design a logo for a business.', 13, NULL),
(27, 'Troubleshoot technology issues.', 1, NULL),
(28, 'Cater a party.', 2, NULL),
(29, 'Ensure a business meets standards.', 3, NULL),
(30, 'Develop lesson plans for classes.', 4, NULL),
(31, 'Help those who are dying, sick, or depressed.', 5, NULL),
(32, 'Prepare a press release.', 6, NULL),
(33, 'Solve math problems.', 7, NULL),
(34, 'Understand and observe the changes in weather patterns or animal migrations.', 8, NULL),
(35, 'Help community during a natural disaster or emergency.', 9, NULL),
(36, 'Study ethics and philosophy.', 10, NULL),
(37, 'Play an instrument.', 11, NULL),
(38, 'Lead recreational activities.', 12, NULL),
(39, 'Design a website.', 13, NULL),
(40, 'Code a website or software application.', 1, NULL),
(41, 'Design a cake for a customer.', 2, NULL),
(42, 'Supervise, hire, and mentor others.', 3, NULL),
(43, 'Teach a large group how to do something.', 4, NULL),
(44, 'Observe, record, and report a patient''s condition.', 5, NULL),
(45, 'Read books and articles.', 6, NULL),
(46, 'Analyze statistical data and trends.', 7, NULL),
(47, 'Research environmental effects on wildlife.', 8, NULL),
(48, 'Ensure federal, state, and local laws are abided by.', 9, NULL),
(49, 'Research other cultures and religions.', 10, NULL),
(50, 'Work as a performer, stagehand, or director.', 11, NULL),
(51, 'Advise people about healthy lifestyle habits.', 12, NULL),
(52, 'Produce a commercial.', 13, NULL),
(53, 'Use technology everyday.', NULL, 1),
(54, 'Work outside most of the time.', NULL, 2),
(55, 'Help people who are in need.', NULL, 3),
(56, 'Build or fix things.', NULL, 4),
(57, 'Spend time with gadgets', NULL, 1),
(58, 'Love going to places', NULL, 2),
(59, 'Donating to charity foundations', NULL, 3),
(60, 'Fix something faulty ', NULL, 4);

-- --------------------------------------------------------

--
-- Table structure for table `result`
--

CREATE TABLE `result` (
  `result_id` int(11) NOT NULL,
  `assessment_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `interest_id` int(11) DEFAULT NULL,
  `career_id` int(11) DEFAULT NULL,
  `percent` int(11) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `password` text,
  `fullname` varchar(60) DEFAULT NULL,
  `date_joined` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user_message`
--

CREATE TABLE `user_message` (
  `message_id` int(11) NOT NULL,
  `conversation_id` int(11) NOT NULL,
  `content` text,
  `read` tinyint(1) DEFAULT NULL,
  `date_time_sent` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `assessment`
--
ALTER TABLE `assessment`
  ADD PRIMARY KEY (`assessment_id`,`user_id`),
  ADD KEY `fk_assessments_user_idx` (`user_id`);

--
-- Indexes for table `career`
--
ALTER TABLE `career`
  ADD PRIMARY KEY (`career_id`);

--
-- Indexes for table `conversation`
--
ALTER TABLE `conversation`
  ADD PRIMARY KEY (`conversation_id`,`assessment_id`,`user_id`),
  ADD KEY `fk_conversation_assessment1_idx` (`assessment_id`,`user_id`),
  ADD KEY `fk_conversation_counselor1_idx` (`counselor_id`);

--
-- Indexes for table `counselor`
--
ALTER TABLE `counselor`
  ADD PRIMARY KEY (`counselor_id`);

--
-- Indexes for table `counselor_message`
--
ALTER TABLE `counselor_message`
  ADD PRIMARY KEY (`message_id`,`conversation_id`),
  ADD KEY `fk_user_message_conversation1_idx` (`conversation_id`);

--
-- Indexes for table `interest`
--
ALTER TABLE `interest`
  ADD PRIMARY KEY (`interest_id`);

--
-- Indexes for table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`question_id`),
  ADD KEY `fk_questions_career1_idx` (`career_id`),
  ADD KEY `fk_questions_interest1_idx` (`interest_id`);

--
-- Indexes for table `result`
--
ALTER TABLE `result`
  ADD PRIMARY KEY (`result_id`,`assessment_id`,`user_id`),
  ADD KEY `fk_result_interest1_idx` (`interest_id`),
  ADD KEY `fk_result_career1_idx` (`career_id`),
  ADD KEY `fk_result_assessment1` (`assessment_id`,`user_id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `user_message`
--
ALTER TABLE `user_message`
  ADD PRIMARY KEY (`message_id`,`conversation_id`),
  ADD KEY `fk_user_message_conversation1_idx` (`conversation_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `assessment`
--
ALTER TABLE `assessment`
  MODIFY `assessment_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `career`
--
ALTER TABLE `career`
  MODIFY `career_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- AUTO_INCREMENT for table `conversation`
--
ALTER TABLE `conversation`
  MODIFY `conversation_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `counselor`
--
ALTER TABLE `counselor`
  MODIFY `counselor_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `counselor_message`
--
ALTER TABLE `counselor_message`
  MODIFY `message_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `interest`
--
ALTER TABLE `interest`
  MODIFY `interest_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `questions`
--
ALTER TABLE `questions`
  MODIFY `question_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;
--
-- AUTO_INCREMENT for table `result`
--
ALTER TABLE `result`
  MODIFY `result_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `user_message`
--
ALTER TABLE `user_message`
  MODIFY `message_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `assessment`
--
ALTER TABLE `assessment`
  ADD CONSTRAINT `fk_assessments_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `conversation`
--
ALTER TABLE `conversation`
  ADD CONSTRAINT `fk_conversation_assessment1` FOREIGN KEY (`assessment_id`,`user_id`) REFERENCES `assessment` (`assessment_id`, `user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_conversation_counselor1` FOREIGN KEY (`counselor_id`) REFERENCES `counselor` (`counselor_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `counselor_message`
--
ALTER TABLE `counselor_message`
  ADD CONSTRAINT `fk_user_message_conversation10` FOREIGN KEY (`conversation_id`) REFERENCES `conversation` (`conversation_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `fk_questions_career1` FOREIGN KEY (`career_id`) REFERENCES `career` (`career_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_questions_interest1` FOREIGN KEY (`interest_id`) REFERENCES `interest` (`interest_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `result`
--
ALTER TABLE `result`
  ADD CONSTRAINT `fk_result_assessment1` FOREIGN KEY (`assessment_id`,`user_id`) REFERENCES `assessment` (`assessment_id`, `user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_result_career1` FOREIGN KEY (`career_id`) REFERENCES `career` (`career_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_result_interest1` FOREIGN KEY (`interest_id`) REFERENCES `interest` (`interest_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `user_message`
--
ALTER TABLE `user_message`
  ADD CONSTRAINT `fk_user_message_conversation1` FOREIGN KEY (`conversation_id`) REFERENCES `conversation` (`conversation_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
