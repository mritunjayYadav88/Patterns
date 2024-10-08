﻿using Design_Patterns.Abstract_Factory_Desgin_Pattern;
using Design_Patterns.Adapter_Pattern;
using Design_Patterns.Command_Pattern.Command;
using Design_Patterns.Command_Pattern.Invoker;
using Design_Patterns.Decorator_Pattern.Base_class;
using Design_Patterns.Decorator_Pattern.Concrete_class;
using Design_Patterns.Facade_Pattern;
using Design_Patterns.Factory_Design_Pattern;
using Design_Patterns.Factory_Method_Pattern;
using Design_Patterns.Observer_Design_Pattern.Observer_Interface;
using Design_Patterns.Observer_Design_Pattern.Subject_implementation;
using Design_Patterns.Observer_Design_Pattern.Subject_Interface;
using Design_Patterns.Strategy_Design_Pattern;
using Design_Patterns.Strategy_Design_Pattern.Behavior;
using Design_Patterns.Strategy_Design_Pattern.DuckCLass;
using Design_Patterns.Template_Method_Pattern;

class Program
{
    static void Main(string[] args)
    {
        //Strategy design pattern

        Duck mallardDuck = new MallardDuck();
        mallardDuck.performQuack();
        mallardDuck.performFly();
        mallardDuck.setFlyBehavior(new FlyNoWay());
        mallardDuck.performFly();

        Duck modelDuck = new ModelDuck();
        modelDuck.performQuack();
        modelDuck.performFly();

        modelDuck.setFlyBehavior(new FlyRocketPowered());
        modelDuck.performFly();

        //Observer design pattern

        Subject topic = new MyTopic();

        Observer obj1 = new MyTopicSubscriber("Obj1");
        Observer obj2 = new MyTopicSubscriber("Obj2");
        Observer obj3 = new MyTopicSubscriber("Obj3");

        topic.register(obj1);
        topic.register(obj2);
        topic.register(obj3);

        obj1.setSubject(topic);
        obj2.setSubject(topic);
        obj3.setSubject(topic);

        obj1.update();

        topic.postMessage("Namma Bengaluru!!");

        //Decorator pattern

        Beverage beverage = new Espresso();
        Console.WriteLine(beverage.getDescription() + " $" + beverage.cost());
        Beverage beverage2 = new DarkRoast();
        beverage2 = new Mocha(beverage2);
        beverage2 = new Mocha(beverage2);
        beverage2 = new Whip(beverage2);

        Console.WriteLine(beverage2.getDescription() + " $" + beverage2.cost());
        Beverage beverage3 = new HouseBlend();
        beverage3 = new Soy(beverage3);
        beverage3 = new Mocha(beverage3);
        beverage3 = new Whip(beverage3);
        Console.WriteLine(beverage3.getDescription() + " $" + beverage3.cost());

        //Factory design pattern

        PizzaStore store = new PizzaStore();
        Pizza pizza = store.orderPizza("cheese");
        Pizza pizza2 = store.orderPizza("veggie");
        Pizza pizza3 = store.orderPizza("pepperoni");

        //Factory method design pattern

        Restaurant beefResto = new BeefBurgerRestaurant();
        Burger beefBurger = beefResto.orderBurger();

        Restaurant veggieResto = new VeggieBurgerRestaurant();
        Burger veggieBurger = veggieResto.orderBurger();

        //Abstract factory design pattern

        Company msi = new MsiManufacturer();
        Gpu msiGpu = msi.createGpu();
        msiGpu.assemble();

        Design_Patterns.Abstract_Factory_Desgin_Pattern.Monitor msiMonitor=msi.createMonitor();
        msiMonitor.assemble();

        Company asus = new AsusManufacturer();
        Gpu asusGpu = asus.createGpu();
        asusGpu.assemble();

        Design_Patterns.Abstract_Factory_Desgin_Pattern.Monitor asusMonitor=asus.createMonitor();
        asusMonitor.assemble();


        //Command Pattern

        RemoteControl remote= new RemoteControl();
        remote.setCommand(new TurnOnACCommand(new Design_Patterns.Command_Pattern.Receiver.AcController()));
        remote.pressButton();
        remote.setCommand(new TurnOffACCommand(new Design_Patterns.Command_Pattern.Receiver.AcController()));
        remote.pressButton();
        remote.undo();
        remote.undo();
        remote.undo();

        //Adapter Pattern

        IDuck turkeyAdater = new TurkeyAdapter(new WildTurkey());

        turkeyAdater.quack();
        turkeyAdater.fly();

        //Template method pattern

        Tea tea=new Tea();
        tea.PrepareRecipe();

        Coffee coffee=new Coffee();
        coffee.PrepareRecipe();

        //Facade pattern

        Order_Facade order_Facade=new Order_Facade();
        order_Facade.orderFood();
    }
}