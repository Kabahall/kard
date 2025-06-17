using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CardShufflingApp
{
    public partial class MainWindow : Window
    {
        private List<Card> originalDeck;
        private List<Card> currentDeck;
        private object p;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDeck();
            DisplayCards();
        }
       
        private void InitializeDeck()
        {
            originalDeck = new List<Card>
            {
                new Card { Key = 1, Name = "Валет", ImagePath ="C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\jack_of_hearts.png"  },
                new Card { Key = 2, Name = "Дама", ImagePath = "C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\queen_of_hearts.png"},
                new Card { Key = 3, Name = "Король" ,ImagePath = "C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\king_of_hearts.png"},
                new Card { Key = 4, Name = "Туз" , ImagePath ="C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\ace_of_hearts.png"},
                new Card { Key = 5, Name = "Двойка" , ImagePath ="C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\2_of_hearts.png"},
                new Card { Key = 6, Name = "Тройка",  ImagePath ="C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\3_of_hearts.png"},
                new Card { Key = 7, Name = "Четвёрка" ,ImagePath = "C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\4_of_hearts.png"},
                new Card { Key = 8, Name = "Пятёрка",  ImagePath ="C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\5_of_hearts.png"},
                new Card { Key = 9, Name = "Шестёрка", ImagePath = "C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\6_of_hearts.png"},
                new Card { Key = 10, Name = "Семёрка" , ImagePath ="C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\7_of_hearts.png"},
                new Card { Key = 11, Name = "Восьмёрка", ImagePath ="C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\8_of_hearts.png" },
                new Card { Key = 12, Name = "Девятка", ImagePath = "C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\9_of_hearts.png"},
                new Card { Key = 13, Name = "Десятка",  ImagePath ="C:\\Users\\KIRA_PC\\програмы\\kart\\kart\\png\\10_of_hearts.png"}
            };

            currentDeck = new List<Card>(originalDeck);
        }

        private void DisplayCards()
        {
            cardsListBox.ItemsSource = currentDeck;
        }

        private void ShuffleCards()
        {
            Random rand = new Random();
            currentDeck = currentDeck.OrderBy(x => rand.Next()).ToList();
            DisplayCards();
        }

        private void SortdNameKeyCards()
        {
            // Сортируем текущую колоду по имени и ключу
            var sortedDeck = originalDeck.OrderBy(p => p.Name).ThenBy(p => p.Key).ToList();

            // Обновляем текущую колоду
            currentDeck = sortedDeck;

            // Выводим отсортированную колоду на экран
            DisplayCards();

            // Для отладки - выводим в консоль
            foreach (var p in currentDeck)
                Console.WriteLine($"{p.Name} - {p.Key}");
        }
     

        private void RestoreInitialOrder()
        {
            currentDeck = new List<Card>(originalDeck);
            DisplayCards();
        }

        private void SearchCard(string name)
        {
            var foundCards = originalDeck.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            currentDeck = foundCards;
            DisplayCards();
        }

        // Обработчики событий для кнопок
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            ShuffleCards();
        }

        //private void ShuffleCards()
        //{
        //    throw new NotImplementedException();
        //}

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            //SortdNameCards();
            SortdNameKeyCards();
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            RestoreInitialOrder();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string cardName = searchTextBox.Text;
            SearchCard(cardName);
        }
    }
}
public class Card
{
    public int Key { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
}