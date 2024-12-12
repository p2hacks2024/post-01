import 'package:flutter/material.dart';

class WeatherRainPage extends StatelessWidget {
  const WeatherRainPage({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'あなたと',
      theme: ThemeData(
        useMaterial3: true,
        appBarTheme: const AppBarTheme(
          backgroundColor: Colors.deepPurple, // AppBarの背景色
        ),
      ),
      home: const WeatherRainHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class WeatherRainHomePage extends StatefulWidget {
  const WeatherRainHomePage({super.key, required this.title});

  final String title;

  @override
  State<WeatherRainHomePage> createState() => _WeatherRainHomePageState();
}

class _WeatherRainHomePageState extends State<WeatherRainHomePage> {
  // String displayText = "スタート";
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text(widget.title), actions: [
        IconButton(
          onPressed: () {},
          icon: const Icon(Icons.arrow_back_ios_new_outlined),
        )
      ]),
      body: const Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          SizedBox(height: 50),
          Text("1.てんきあめ"),
          Center(
              child: Column(children: [
            Text("説明"),
          ]))
        ],
      ),
      backgroundColor: Colors.grey,
    );
    // body: IconButton(
    //   onPressed: () {},
    //   icon: const Icon(Icons.arrow_back_ios_new_outlined),
    // ));
  }
}
