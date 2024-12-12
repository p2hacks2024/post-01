import 'package:flutter/material.dart';
import 'package:with_you/actual_results.dart';

import 'game_page.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

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
      home: const MyHomePage(title: 'Flutter Demo Home Page'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});
  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  String displayText = "スタート";
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Center(
        child: Column(
          children: [
            const Text(
              "タイトル画面",
              style: TextStyle(fontSize: 30),
            ),
            GestureDetector(
              onTap: () {
                // タップされたときにテキストを変更
                Navigator.push(context,
                    MaterialPageRoute(builder: (context) => const GamePage()));
              },
              child: Text(
                displayText,
                style: const TextStyle(fontSize: 18),
              ),
            ),
          ],
        ),
      ),
      bottomNavigationBar: BottomAppBar(
        child: Row(mainAxisAlignment: MainAxisAlignment.center, children: [
          IconButton(
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => const ActualResultsPage()));
              },
              icon: ClipRRect(
                borderRadius: BorderRadius.circular(100),
                child: Container(
                  color: Colors.blue,
                  width: 40,
                  height: 40,
                ),
              )),
          const SizedBox(width: 30),
          IconButton(
              onPressed: () {},
              icon: ClipRRect(
                borderRadius: BorderRadius.circular(100),
                child: Container(
                  color: Colors.blue,
                  width: 40,
                  height: 40,
                ),
              )),
          const SizedBox(width: 30),
          IconButton(
              onPressed: () {},
              icon: ClipRRect(
                borderRadius: BorderRadius.circular(100),
                child: Container(
                  color: Colors.blue,
                  width: 40,
                  height: 40,
                ),
              )),
        ]),
      ),
    );
  }
}
