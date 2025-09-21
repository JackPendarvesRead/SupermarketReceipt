// See https://aka.ms/new-console-template for more information
using SupermarketReceipt;

var cart = new ShoppingCart();
var teller = new Teller(new FakeCatalog(), cart);
var receipt = teller.ChecksOutArticlesFrom();