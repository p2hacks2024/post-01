import 'package:flutter/material.dart';

// これはテスト画面です
class TestPage extends StatelessWidget {
  const TestPage({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        useMaterial3: true,
        appBarTheme: const AppBarTheme(
          backgroundColor: Colors.deepPurple, // AppBarの背景色
        ),
      ),
      home: const TestHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class TestHomePage extends StatefulWidget {
  const TestHomePage({super.key, required this.title});

  final String title;

  @override
  State<TestHomePage> createState() => _TestHomePageState();
}

class _TestHomePageState extends State<TestHomePage> {
  // String displayText = "スタート";
  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      // appBar: AppBar(
      //   title: Text(widget.title),
      // ),
      body:  Center(
        child: Text(
          "Hello World!!",
          style: TextStyle(fontSize: 30),
        ),
      ),
    );
  }
}
