import 'package:flutter/material.dart';
import 'package:with_you/actual_results.dart';

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
  @override
  Widget build(BuildContext context) {
    return  Scaffold(
        body: Container(
        decoration:  const BoxDecoration(
        image: DecorationImage(image:
        AssetImage('lib/image/image.png'),)),
      child:   Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const SizedBox(height: 75),
          IconButton(onPressed: (){
            Navigator.push(
                context,
                MaterialPageRoute(
                    builder: (context) => const ActualResultsPage()));
          }, icon:
          Image.asset('lib/image/icon_back.png'),),
          const SizedBox(height: 50),
          const Padding(padding: EdgeInsets.only(left: 30),
          child: Text(
            "１.　てんきあめ",
            style: TextStyle(fontSize: 25, color: Colors.black, fontFamily: 'ZenKurenaido'),)),
          const Center(
              child: Column(children: [
           // 画像が入る予定
          ])),
          const SizedBox(height: 290),
          const Text('''
          晴れているときに
          上から下にスワイプして
          雨を降らせる''',style: TextStyle(fontSize: 20, color: Colors.black, fontFamily: 'ZenKurenaido')),
          const SizedBox(height: 20),
          Row(
              children: [
                Padding(padding: const EdgeInsets.only(left: 10),
                    child:IconButton(onPressed: (){}, icon: Image.asset("lib/image/icon_arrow2.png")),),
                Padding(padding: const EdgeInsets.only(left: 180),
                    child: IconButton(onPressed: (){}, icon: Image.asset("lib/image/icon_arrow.png"))
                )
              ]
          ),
        ],
      ),)
    );
  }
}
