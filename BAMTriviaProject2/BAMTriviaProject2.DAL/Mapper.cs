﻿using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAMTriviaProject2.DAL
{
    public class Mapper
    {
        //public static Orders Map(OrderImp Order) => new Orders
        //{
        //    OrderId = Order.OrderID,
        //    OrderDate = Order.OrderDate,
        //    OrderCustomerId = Order.OrderCustomer,
        //    OrderCost = Order.TotalOrderCost(),
        //    OrderStoreId = Order.StoreId
        //};

        //public static OrderImp Map(Orders Order) => new OrderImp
        //{
        //    OrderID = Order.OrderId,
        //    OrderDate = Order.OrderDate,
        //    OrderCustomer = Order.OrderCustomerId,
        //    OrderCost = Order.OrderCost,
        //    StoreId = Order.OrderStoreId,

        //    GamesInOrder = Map(Order.OrderGames).ToList(),
        //};

        public static Answers Map(AnswerModel answers) => new Answers
        {

        };

        public static AnswerModel Map(Answers answers) => new AnswerModel
        {

        };

        public static Questions Map(QuestionsModel answers) => new Questions
        {

        };

        public static QuestionsModel Map(Questions answers) => new QuestionsModel
        {

        };

        public static Quiz Map(QuizesModel answers) => new Quiz
        {

        };

        public static QuizesModel Map(Quiz answers) => new QuizesModel
        {

        };

        public static QuizResults Map(QuizResultsModel answers) => new QuizResults
        {

        };

        public static QuizResultsModel Map(QuizResults answers) => new QuizResultsModel
        {

        };

        public static Reviews Map(ReviewsModel answers) => new Reviews
        {

        };

        public static ReviewsModel Map(Reviews answers) => new ReviewsModel
        {

        };

        public static Tusers Map(UsersModel answers) => new Tusers
        {

        };

        public static UsersModel Map(Tusers answers) => new UsersModel
        {

        };

        public static UserQuizzes Map(UserQuizesModel answers) => new UserQuizzes
        {

        };

        public static UserQuizesModel Map(UserQuizzes answers) => new UserQuizesModel
        {

        };
    }
}