using System;
using System.IO;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;

namespace TestGeneration
{
    class Test
    {
        Word.Document document;
        Word.Application app;

        int variant;

        public Test(int variant)
        {
            this.variant = variant;

            try
            {
                OpenFile();
            }
            catch (FileNotFoundException)
            {
                throw;
            }

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "TestVariant", variant.ToString() },
                { "AnswersVariant", variant.ToString() }
            };

            AddBookmarks(bookmarks);

            CompleteAllTasks();
            CloseFile();
        }

        // МЕТОДЫ, ОТВЕЧАЮЩИЕ ЗА КОРРЕКТНОЕ ОТКРЫТИЕ И ЗАКРЫТИЕ ФАЙЛА ШАБЛОНА,
        // А ТАКЖЕ СОЗДАНИЕ НОВОГО ФАЙЛА С СООТВЕТСТВУЮЩИМ ВАРИАНТОМ

        private void OpenFile()
        {
            string pathDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string sourcePath = $@"{pathDirectory}\.template\template.docx";
            string destinationPath = $@"{pathDirectory}\ТЕСТЫ\Вариант №{variant}.docx";

            document = null;

            try
            {
                app = new Word.Application();

                document = app.Documents.Add(sourcePath, Type.Missing, Type.Missing, true);
                document.SaveAs(destinationPath);

                document.Activate();
            }
            catch (Exception)
            {
                document.Close();
                document = null;

                app.Quit();

                throw new FileNotFoundException();
            }
        }

        private void CloseFile()
        {
            document.Close();
            document = null;

            app.Quit();
        }

        // МЕТОДЫ, ОТВЕЧАЮЩИЕ ЗА ВСТАВКУ В ФАЙЛ ШАБЛОНА

        private void AddBookmarks(Dictionary<string, string> bookmarks)
        {
            foreach (var bookmark in bookmarks)
            {
                Word.Bookmark bm = document.Bookmarks[bookmark.Key];
                Word.Range range = bm.Range;
                range.Text = bookmark.Value;
                document.Bookmarks.Add(bookmark.Key, range);
            }
        }

        // ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ РЕШЕНИЯ ЗАДАЧ

        private int Factorial(int x)
        {
            return (x > 1) ? x * Factorial(x - 1) : 1;
        }

        // факториал в диапазоне [border; x]
        private int FactorialPlus(int x, int border)
        {
            return (x > border) ? x * FactorialPlus(x - 1, border) : 1;
        }

        private int Combinations(int k, int n)
        {
            return FactorialPlus(n, n - k) / Factorial(k);
        }

        // сокращение дроби
        private void ReduceFraction(ref int numerator, ref int denominator)
        {
            if ((numerator == 1) || (denominator == 1))
                return;

            int divisor = (numerator < denominator) ? numerator : denominator;

            if ((numerator % divisor == 0) && (denominator % divisor == 0))
            {
                numerator /= divisor;
                denominator /= divisor;

                ReduceFraction(ref numerator, ref denominator);
            }
            else
            {
                divisor /= 2;

                for (; divisor > 1; divisor--)
                {
                    if ((numerator % divisor == 0) && (denominator % divisor == 0))
                    {
                        numerator /= divisor;
                        denominator /= divisor;

                        break;
                    }
                }

                if (divisor != 1)
                    ReduceFraction(ref numerator, ref denominator);
            }
        }

        // МЕТОДЫ, ОТВЕЧАЮЩИЕ ЗА ПЕРЕТАСОВКУ ОТВЕТОВ

        // перетасовка ответов
        private void FisherYatesShuffle<T>(ref List<T> answers)
        {
            Random random = new Random();
            for (int i = answers.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                T temp = answers[j];
                answers[j] = answers[i];
                answers[i] = temp;
            }
        }

        // выдача буквы ответа
        private string GetAnswerLetter<T>(List<T> answers, T trueAnswer)
        {
            int numberAnswer = answers.IndexOf(trueAnswer);

            switch (numberAnswer)
            {
                case 0: return "a)";
                case 1: return "б)";
                case 2: return "в)";
                case 3: return "г)";
                default: throw new ArgumentException("Ответ не найден");
            }
        }

        // МЕТОДЫ, ОТВЕЧАЮЩИЕ ЗА ГЕНЕРАЦИЮ ЗАДАНИЙ

        private void CompleteAllTasks()
        {
            CompleteTask1();
            CompleteTask2();
            CompleteTask3();
            CompleteTask4();
            CompleteTask5();
            CompleteTask6();
            CompleteTask7();
            CompleteTask8();
            CompleteTask9();
            CompleteTask10();
            CompleteTask11();
            CompleteTask12();
            CompleteTask13();
        }

        private void CompleteTask1()
        {
            Random random = new Random();

            int meat = random.Next(6, 10);
            int cabbage = random.Next(4, 10);
            int numberOfPies = meat + cabbage;

            int willBe = random.Next(2, 4);
            int takeItOut = random.Next(willBe + 1, 5);

            int comb1 = Combinations(willBe, meat);
            int comb2 = Combinations(takeItOut - willBe, cabbage);
            int comb3 = Combinations(takeItOut, numberOfPies);

            int numerator = comb1 * comb2;
            int denominator = comb3;
            ReduceFraction(ref numerator, ref denominator);

            string trueAnswer = $"{numerator}/{denominator}";

            List<string> answers = new List<string>
            {
                trueAnswer,
                $"{random.Next(1, numerator)}/{denominator}",
                $"{numerator}/{random.Next(numerator, denominator)}",
                $"{random.Next(1, numerator)}/{random.Next(numerator, denominator)}"
            };

            FisherYatesShuffle<string>(ref answers);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "Meat_1_1", meat.ToString() },
                { "Cabbage_1_2", cabbage.ToString() },
                { "TakeItOut_1_3", takeItOut.ToString() },
                { "WillBe_1_4", willBe.ToString() },

                { "Choice_1_1", answers[0] },
                { "Choice_1_2", answers[1] },
                { "Choice_1_3", answers[2] },
                { "Choice_1_4", answers[3] },

                { "Answer_1", GetAnswerLetter<string>(answers, trueAnswer) },
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask2()
        {
            Random random = new Random();

            int radius = random.Next(2, 8);
            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "Radius_2_1", radius.ToString() },
                { "ChoiceDown_2_1", radius.ToString() },
                { "ChoiceDown_2_2", (radius * radius).ToString() }
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask3()
        {
            Random random = new Random();

            double shooter1 = random.Next(80, 100) * 0.01;
            double shooter2 = random.Next(80, 100) * 0.01;

            double trueAnswer = shooter1 * (1 - shooter2) + shooter2 * (1 - shooter1);

            List<double> answers = new List<double>
            {
                trueAnswer,
                shooter1 - 0.01,
                shooter1 * (1 - shooter2),
                shooter2 * (1 - shooter1)
            };

            FisherYatesShuffle<double>(ref answers);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "Shooter_3_1", shooter1.ToString() },
                { "Shooter_3_2", shooter2.ToString() },

                { "Choice_3_1", Math.Round(answers[0], 2).ToString() },
                { "Choice_3_2", Math.Round(answers[1], 2).ToString() },
                { "Choice_3_3", Math.Round(answers[2], 2).ToString() },
                { "Choice_3_4", Math.Round(answers[3], 2).ToString() },

                { "Answer_3", GetAnswerLetter<double>(answers, trueAnswer) },
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask4()
        {
            Random random = new Random();

            int sumOfPoints = 0;
            int suitableVariants = 0;
            List<int> wrongVariants = new List<int>(3);

            if (random.Next() % 2 == 0)
            {
                sumOfPoints = random.Next(3, 8);
                switch (sumOfPoints)
                {
                    case (3):
                        suitableVariants = 215;
                        break;
                    case (4):
                        suitableVariants = 212;
                        break;
                    case (5):
                        suitableVariants = 206;
                        break;
                    case (6):
                        suitableVariants = 196;
                        break;
                    case (7):
                        suitableVariants = 181;
                        break;
                }

                wrongVariants.Add(suitableVariants - 16);
                wrongVariants.Add(suitableVariants / 2);
                wrongVariants.Add(suitableVariants / 3);
            }
            else
            {
                sumOfPoints = random.Next(13, 18);
                switch (sumOfPoints)
                {
                    case (13):
                        suitableVariants = 35;
                        break;
                    case (14):
                        suitableVariants = 20;
                        break;
                    case (15):
                        suitableVariants = 10;
                        break;
                    case (16):
                        suitableVariants = 4;
                        break;
                    case (17):
                        suitableVariants = 1;
                        break;
                }

                wrongVariants.Add(suitableVariants + 16);
                wrongVariants.Add(suitableVariants * 2);
                wrongVariants.Add(suitableVariants * 3);
            }

            double allVariants = 216;
            double trueAnswer = suitableVariants / allVariants;

            List<double> answers = new List<double>
            {
                trueAnswer,
                wrongVariants[0] / allVariants,
                wrongVariants[1] / allVariants,
                wrongVariants[2] / allVariants,
            };

            FisherYatesShuffle<double>(ref answers);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "Sum_4_1", sumOfPoints.ToString() },

                { "Choice_4_1", Math.Round(answers[0], 2).ToString() },
                { "Choice_4_2", Math.Round(answers[1], 2).ToString() },
                { "Choice_4_3", Math.Round(answers[2], 2).ToString() },
                { "Choice_4_4", Math.Round(answers[3], 2).ToString() },

                { "Answer_4", GetAnswerLetter<double>(answers, trueAnswer) },
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask5()
        {
            Random random = new Random();

            double blueBalls1 = random.Next(4, 9);
            double yellowBalls1 = 10 - blueBalls1;

            double yellowBalls2 = random.Next(4, 9);
            double blueBalls2 = 10 - yellowBalls2;

            double probability1 = blueBalls1 / (blueBalls1 + yellowBalls1);
            double probability2 = blueBalls2 / (blueBalls2 + yellowBalls2);
            double overallProbability = 0.5 * (probability1 + probability2);

            double trueAnswer = (0.5 * probability2) / overallProbability;

            List<double> answers = new List<double>
            {
                trueAnswer,
                probability2,
                probability2 * 0.5,
                overallProbability
            };

            FisherYatesShuffle<double>(ref answers);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "Blue_5_1", blueBalls1.ToString() },
                { "Yellow_5_2", yellowBalls1.ToString() },
                { "Yellow_5_3", yellowBalls2.ToString() },
                { "Blue_5_4", blueBalls2.ToString() },

                { "Choice_5_1", Math.Round(answers[0], 2).ToString() },
                { "Choice_5_2", Math.Round(answers[1], 2).ToString() },
                { "Choice_5_3", Math.Round(answers[2], 2).ToString() },
                { "Choice_5_4", Math.Round(answers[3], 2).ToString() },

                { "Answer_5", GetAnswerLetter<double>(answers, trueAnswer) },
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask6()
        {
            Random random = new Random();

            int people = random.Next(5, 10);
            int students = random.Next(2, 5);
            double p = random.Next(70, 91) * 0.01;
            double q = 1 - p;

            int comb = Combinations(students, people);

            double trueAnswer = comb * Math.Pow(p, students) * Math.Pow(1 - p, people - students);

            List<double> answers = new List<double>
            {
                trueAnswer,
                (students * p) / 10,
                comb / 100.0,
                (comb * p * q) / 10
            };

            FisherYatesShuffle<double>(ref answers);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "Percent_6_1", (p * 100).ToString() },
                { "People_6_2", people.ToString() },
                { "Students_6_3", students.ToString() },

                { "Choice_6_1", Math.Round(answers[0], 4).ToString() },
                { "Choice_6_2", Math.Round(answers[1], 4).ToString() },
                { "Choice_6_3", Math.Round(answers[2], 4).ToString() },
                { "Choice_6_4", Math.Round(answers[3], 4).ToString() },

                { "Answer_6", GetAnswerLetter<double>(answers, trueAnswer) },
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask7()
        {
            Random random = new Random();

            int rightBorder1 = random.Next(1, 6);
            int leftBorder2 = rightBorder1;
            int rightBorder2 = leftBorder2 + 1;
            int leftBorder3 = rightBorder2;
            int rightBorder3 = leftBorder3 + 1;
            int leftBorder4 = rightBorder3;
            int rightBorder4 = leftBorder4 + 1;
            int rightBorder5 = rightBorder4;

            double value2 = random.Next(1, 4) * 0.1;
            double value3 = random.Next(4, 7) * 0.1;
            double value4 = random.Next(7, 10) * 0.1;

            int selectedLeftBorder, selectedRightBorder;
            double trueAnswer, wrongAnswer1, wrongAnswer2;

            if (random.Next() % 2 == 0)
            {
                selectedLeftBorder = leftBorder2;
                selectedRightBorder = rightBorder3;

                trueAnswer = value3 - value2;

                wrongAnswer1 = value3;
                wrongAnswer2 = value4 - value3;
            }
            else
            {
                selectedLeftBorder = leftBorder3;
                selectedRightBorder = rightBorder4;

                trueAnswer = value4 - value3;

                wrongAnswer1 = value4;
                wrongAnswer2 = value3 - value2;
            }

            List<double> answers = new List<double>
            {
                trueAnswer,
                wrongAnswer1,
                wrongAnswer2,
                0
            };

            FisherYatesShuffle<double>(ref answers);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "RightBorder_7_1", rightBorder1.ToString() },

                { "Value_7_2", value2.ToString() },
                { "LeftBorder_7_2", leftBorder2.ToString() },
                { "RightBorder_7_2", rightBorder2.ToString() },

                { "Value_7_3", value3.ToString() },
                { "LeftBorder_7_3", leftBorder3.ToString() },
                { "RightBorder_7_3", rightBorder3.ToString() },

                { "Value_7_4", value4.ToString() },
                { "LeftBorder_7_4", leftBorder4.ToString() },
                { "RightBorder_7_4", rightBorder4.ToString() },

                { "RightBorder_7_5", rightBorder5.ToString() },

                { "SelectedLeftBorder_7", selectedLeftBorder.ToString() },
                { "SelectedRightBorder_7", selectedRightBorder.ToString() },

                { "Choice_7_1", answers[0].ToString() },
                { "Choice_7_2", answers[1].ToString() },
                { "Choice_7_3", answers[2].ToString() },
                { "Choice_7_4", answers[3].ToString() },

                { "Answer_7", GetAnswerLetter<double>(answers, trueAnswer) },
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask8()
        {
            List<double> probability = new List<double> { 0.1, 0.2, 0.3, 0.4 };
            FisherYatesShuffle<double>(ref probability);

            List<double> trueAnswer = new List<double>
            {
                0,
                probability[0],
                probability[0] + probability[1],
                probability[0] + probability[1] + probability[2],
                1
            };

            List<double> wrongAnswer1 = new List<double> { 0, 0.1, 0.2, 0.3, 0 };

            List<double> wrongAnswer2 = new List<double>
            {
                trueAnswer[4],
                trueAnswer[3],
                trueAnswer[2],
                trueAnswer[1],
                trueAnswer[0],
            };

            List<double> wrongAnswer3 = new List<double>
            {
                0,
                probability[3],
                probability[3] + probability[1],
                probability[3] + probability[1] + probability[0],
                1
            };

            List<List<double>> answers = new List<List<double>>
            {
                trueAnswer,
                wrongAnswer1,
                wrongAnswer2,
                wrongAnswer3
            };

            FisherYatesShuffle<List<double>>(ref answers);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                 { "Probability_8_1", probability[0].ToString() },
                 { "Probability_8_2", probability[1].ToString() },
                 { "Probability_8_3", probability[2].ToString() },
                 { "Probability_8_4", probability[3].ToString() },

                 { "Choice_8_1_1", answers[0][0].ToString() },
                 { "Choice_8_1_2", answers[0][1].ToString() },
                 { "Choice_8_1_3", answers[0][2].ToString() },
                 { "Choice_8_1_4", answers[0][3].ToString() },
                 { "Choice_8_1_5", answers[0][4].ToString() },

                 { "Choice_8_2_1", answers[1][0].ToString() },
                 { "Choice_8_2_2", answers[1][1].ToString() },
                 { "Choice_8_2_3", answers[1][2].ToString() },
                 { "Choice_8_2_4", answers[1][3].ToString() },
                 { "Choice_8_2_5", answers[1][4].ToString() },

                 { "Choice_8_3_1", answers[2][0].ToString() },
                 { "Choice_8_3_2", answers[2][1].ToString() },
                 { "Choice_8_3_3", answers[2][2].ToString() },
                 { "Choice_8_3_4", answers[2][3].ToString() },
                 { "Choice_8_3_5", answers[2][4].ToString() },

                 { "Choice_8_4_1", answers[3][0].ToString() },
                 { "Choice_8_4_2", answers[3][1].ToString() },
                 { "Choice_8_4_3", answers[3][2].ToString() },
                 { "Choice_8_4_4", answers[3][3].ToString() },
                 { "Choice_8_4_5", answers[3][4].ToString() },

                 { "Answer_8", GetAnswerLetter<List<double>>(answers, trueAnswer) }
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask9()
        {
            Random random = new Random();

            int constantUp = random.Next(3, 10);
            int degree = constantUp - 1;
            double constantDown = Math.Pow(2, constantUp);

            Dictionary<string, string> trueAnswer = new Dictionary<string, string>
            {
                { "constantUp", "" },
                { "degree", constantUp.ToString() },
                { "constantDown", constantDown.ToString() }
            };

            Dictionary<string, string> wrongAnswer1 = new Dictionary<string, string>
            {
                { "constantUp", constantDown.ToString() },
                { "degree", degree.ToString() },
                { "constantDown", constantUp.ToString() }
            };

            Dictionary<string, string> wrongAnswer2 = new Dictionary<string, string>
            {
                { "constantUp", constantUp.ToString() },
                { "degree", degree.ToString() },
                { "constantDown", constantDown.ToString() }
            };

            List<Dictionary<string, string>> answers = new List<Dictionary<string, string>>
            {
                trueAnswer,
                wrongAnswer1,
                wrongAnswer2
            };

            FisherYatesShuffle<Dictionary<string, string>>(ref answers);
            string answerLetter = GetAnswerLetter<Dictionary<string, string>>(answers, trueAnswer);

            if (answerLetter == "a)")
                answerLetter = "б)";
            else if (answerLetter == "б)")
                answerLetter = "в)";
            else
                answerLetter = "г)";

            answers.Insert(0, trueAnswer);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "ConstantUp_9", constantUp.ToString() },
                { "Degree_9", degree.ToString() },
                { "ConstantDown_9", constantDown.ToString() },

                { "Choice_9_1_ConstantUp", answers[0]["constantUp"] },
                { "Choice_9_1_Degree", answers[0]["degree"] },
                { "Choice_9_1_ConstantDown", answers[0]["constantDown"] },

                { "Choice_9_2_ConstantUp", answers[1]["constantUp"] },
                { "Choice_9_2_Degree", answers[1]["degree"] },
                { "Choice_9_2_ConstantDown", answers[1]["constantDown"] },

                { "Choice_9_3_ConstantUp", answers[2]["constantUp"] },
                { "Choice_9_3_Degree", answers[2]["degree"] },
                { "Choice_9_3_ConstantDown", answers[2]["constantDown"] },

                { "Choice_9_4_ConstantUp", answers[3]["constantUp"] },
                { "Choice_9_4_Degree", answers[3]["degree"] },
                { "Choice_9_4_ConstantDown", answers[3]["constantDown"] },

                { "Answer_9", answerLetter }
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask10()
        {
            Random random = new Random();

            int border = random.Next(4, 10);
            int number = border * border;

            int leftBorder = random.Next(1, border);
            int rightBorder = random.Next(border + 1, 15);

            int numerator = number - leftBorder * leftBorder;
            int denominator = number;
            ReduceFraction(ref numerator, ref denominator);

            string trueAnswer = $"{numerator}/{denominator}";

            int wrN1 = leftBorder * leftBorder;
            int wrD1 = rightBorder * rightBorder;
            ReduceFraction(ref wrN1, ref wrD1);

            int wrN2 = leftBorder;
            int wrD2 = rightBorder * rightBorder;
            ReduceFraction(ref wrN2, ref wrD2);

            int wrN3 = rightBorder - leftBorder;
            int wrD3 = number;
            ReduceFraction(ref wrN3, ref wrD3);

            List<string> answers = new List<string>
            {
                trueAnswer,
                $"{wrN1}/{wrD1}",
                $"{wrN2}/{wrD2}",
                $"{wrN3}/{wrD3}",
            };

            FisherYatesShuffle<string>(ref answers);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "Number_10",  number.ToString() },
                { "RightBorder_10_2",  border.ToString() },
                { "RightBorder_10_3",  border.ToString() },

                { "LeftBorder_10",  leftBorder.ToString() },
                { "RightBorder_10",  rightBorder.ToString() },

                { "Choice_10_1",  answers[0] },
                { "Choice_10_2",  answers[1] },
                { "Choice_10_3",  answers[2] },
                { "Choice_10_4",  answers[3] },

                { "Answer_10", GetAnswerLetter<string>(answers, trueAnswer) }
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask11()
        {
            Random random = new Random();

            int a = random.Next(1, 4);
            int q = random.Next(2, 10);
            int q22 = 2 * q * q;

            double leftBorder = random.Next(4, 8);
            double rightBorder = random.Next(8, 12);

            double f1 = (rightBorder - a) / q;
            double f2 = (leftBorder - a) / q;

            Dictionary<string, string> trueAnswer = new Dictionary<string, string>
            {
                { "leftValue",  Math.Round(f1, 2).ToString() },
                { "rightValue", Math.Round(f2, 2).ToString()  },
                { "sign", "-"}
            };

            Dictionary<string, string> wrongAnswer1 = new Dictionary<string, string>
            {
                { "leftValue", trueAnswer["rightValue"] },
                { "rightValue", trueAnswer["leftValue"] },
                { "sign", "-" }
            };

            Dictionary<string, string> wrongAnswer2 = new Dictionary<string, string>
            {
                { "leftValue", trueAnswer["leftValue"] },
                { "rightValue", trueAnswer["rightValue"] },
                { "sign", "+" }
            };

            Dictionary<string, string> wrongAnswer3 = new Dictionary<string, string>
            {
                { "leftValue", Math.Round(rightBorder / q, 2).ToString() },
                { "rightValue", Math.Round(leftBorder / q, 2).ToString() },
                { "sign", "+" }
            };

            List<Dictionary<string, string>> answers = new List<Dictionary<string, string>>
            {
                trueAnswer,
                wrongAnswer1,
                wrongAnswer2,
                wrongAnswer3
            };

            FisherYatesShuffle<Dictionary<string, string>>(ref answers);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "q_11", q.ToString() },
                { "q22_11", q22.ToString() },
                { "a_11", a.ToString() },

                { "leftBorder_11_1", leftBorder.ToString() },
                { "rightBorder_11_1", rightBorder.ToString() },

                { "leftBorder_11_2", leftBorder.ToString() },
                { "rightBorder_11_2", rightBorder.ToString() },

                { "Choice_11_1_leftValue", answers[0]["leftValue"] },
                { "Choice_11_1_rightValue", answers[0]["rightValue"] },
                { "Choice_11_1_sign", answers[0]["sign"] },

                { "Choice_11_2_leftValue", answers[1]["leftValue"] },
                { "Choice_11_2_rightValue", answers[1]["rightValue"] },
                { "Choice_11_2_sign", answers[1]["sign"] },

                { "Choice_11_3_leftValue", answers[2]["leftValue"] },
                { "Choice_11_3_rightValue", answers[2]["rightValue"] },
                { "Choice_11_3_sign", answers[2]["sign"] },

                { "Choice_11_4_leftValue", answers[3]["leftValue"] },
                { "Choice_11_4_rightValue", answers[3]["rightValue"] },
                { "Choice_11_4_sign", answers[3]["sign"] },

                { "Answer_11", GetAnswerLetter<Dictionary<string, string>>(answers, trueAnswer) }
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask12()
        {
            Random random = new Random();

            int point1 = random.Next(-3, 0);
            int point2 = random.Next(1, 6);
            int point3 = random.Next(6, 10);

            double probability1 = random.Next(1, 4) * 0.1;
            double probability2 = random.Next(1, 6) * 0.1;
            double probability3 = 1 - probability1 - probability2;

            double trueAnswer = (point1 * probability1) + (point2 * probability2) + (point3 * probability3);

            List<double> answers = new List<double>
            {
                trueAnswer,
                point1 + point2 + point3,
                probability1 * probability2 * probability3,
                (point1 * probability3) + (point2 * probability2) + (point3 * probability1)
            };

            FisherYatesShuffle<double>(ref answers);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "Point_12_1", point1.ToString() },
                { "Point_12_2", point2.ToString() },
                { "Point_12_3", point3.ToString() },

                { "Probability_12_1", probability1.ToString() },
                { "Probability_12_2", probability2.ToString() },
                { "Probability_12_3", probability3.ToString() },

                { "Choice_12_1", Math.Round(answers[0], 2).ToString() },
                { "Choice_12_2", Math.Round(answers[1], 2).ToString() },
                { "Choice_12_3", Math.Round(answers[2], 2).ToString() },
                { "Choice_12_4", Math.Round(answers[3], 2).ToString() },

                { "Answer_12", GetAnswerLetter<double>(answers, trueAnswer) }
            };

            AddBookmarks(bookmarks);
        }

        private void CompleteTask13()
        {
            Random random = new Random();

            int rightBorder = random.Next(4, 10);
            int value = rightBorder * rightBorder;

            int numerator = 2 * rightBorder;
            int denominator = 9;
            ReduceFraction(ref numerator, ref denominator);

            string trueAnswer = $"{numerator}/{denominator}";

            int wrN = 2 * rightBorder;
            int wrD = value;
            ReduceFraction(ref wrN, ref wrD);

            List<string> answers = new List<string>
            {
                trueAnswer,
                $"{wrN}/{wrD}",
                $"{denominator}/{numerator}",
                $"1/{rightBorder}"
            };

            FisherYatesShuffle<string>(ref answers);

            Dictionary<string, string> bookmarks = new Dictionary<string, string>
            {
                { "Value_13", value.ToString() },
                { "RightBorder_13_2", rightBorder.ToString() },
                { "RightBorder_13_3", rightBorder.ToString() },

                { "Choice_13_1", answers[0] },
                { "Choice_13_2", answers[1] },
                { "Choice_13_3", answers[2] },
                { "Choice_13_4", answers[3] },

                { "Answer_13", GetAnswerLetter<string>(answers, trueAnswer) }
            };

            AddBookmarks(bookmarks);
        }
    }
}