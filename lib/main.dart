import 'package:flutter/material.dart';
import 'package:with_you/test/test_page.dart';

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
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: ElevatedButton(onPressed: (){
          // 下にスワイプする処理を書く
          Navigator.of(context).push(
            PageRouteBuilder(pageBuilder: (context,animation,secondaryAnimation) {
              return const TestPage(); // テスト画面を表示しているのでここをunityの画面にしたい
            },
            transitionsBuilder: (context, animation, secondaryAnimation, child) {
              const Offset begin =  Offset(0.0, -1.0);
              const Offset end = Offset.zero;
              final Animatable<Offset> tween = Tween(begin: begin, end: end)
              .chain(CurveTween(curve: Curves.easeInOut));
              final Animation<Offset> offsetAnimation = animation.drive(tween);
              return SlideTransition(position: offsetAnimation, child: child,);
            })
          );
        }, child: Container(
        decoration: const BoxDecoration(
        image: DecorationImage(image:
        AssetImage('lib/image/image3.png'),)),
        ))
     );
  }
}

