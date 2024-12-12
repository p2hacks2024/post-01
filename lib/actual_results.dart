import 'package:flutter/material.dart';
import 'package:with_you/weather_rain.dart';

class ActualResultsPage extends StatelessWidget {
  const ActualResultsPage({super.key});

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
      home: const ActualResultsHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class ActualResultsHomePage extends StatefulWidget {
  const ActualResultsHomePage({super.key, required this.title});

  final String title;

  @override
  State<ActualResultsHomePage> createState() => _ActualResultsHomePageState();
}

class _ActualResultsHomePageState extends State<ActualResultsHomePage> {
  // String displayText = "スタート";
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const SizedBox(height: 50),
          const Text("もくじ"),
          Center(
              child: Column(children: [
            TextButton(
              child: const Text(
                "1.てんきあめ",
              ),
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => const WeatherRainPage()));
              },
            ),
            TextButton(
              child: const Text("2.なんとか"),
              onPressed: () {},
            ),
            TextButton(
              child: const Text("3.なんとか"),
              onPressed: () {},
            ),
            const SizedBox(height: 50),
            Align(
                alignment: Alignment.centerRight,
                child: IconButton(
                    onPressed: () {},
                    icon: const Icon(Icons.arrow_forward_ios_outlined)))
          ]))
        ],
      ),
      backgroundColor: Colors.grey,
    );
  }
}
