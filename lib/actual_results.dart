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
  @override
  Widget build(BuildContext context) {
    return Scaffold(

      body: Container(
        decoration: const BoxDecoration(
          image: DecorationImage(image:
          AssetImage('lib/image/image.png'),)),
      child:Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [

          const SizedBox(height: 200),
          const Padding(padding: EdgeInsets.only(left: 30),
          child: Text("もくじ",style: TextStyle(fontSize: 30, fontFamily: 'ZenKurenaido'),),),

            const SizedBox(height: 5),
          Padding(padding: const EdgeInsets.only(left: 20),
            child:TextButton(
              child: const Text(
                "１.　てんきあめ",
              style: TextStyle(fontSize: 25, color: Colors.black, fontFamily: 'ZenKurenaido'),),
              onPressed: () {
                Navigator.push(
                    context,
                    MaterialPageRoute(
                        builder: (context) => const WeatherRainPage()));
              },
            ),),
          Padding(padding: const EdgeInsets.only(left: 20),
            child: TextButton(
              child: const Text("２.　なんとか",style: TextStyle(fontSize: 25, color: Colors.black, fontFamily: 'ZenKurenaido'),),
              onPressed: () {},
            ),),
          Padding(padding: const EdgeInsets.only(left: 20),
            child: TextButton( // 文字サイズ大きくしよう1.5倍
              child: const Text("３.　一富士二鷹三茄子",style: TextStyle(fontSize: 25, color: Colors.black, fontFamily: 'ZenKurenaido'),),
              onPressed: () {},
            ),),
          const SizedBox(height: 220),
          Row(
              children: [
                Padding(padding: const EdgeInsets.only(left: 260),
                    child: IconButton(onPressed: (){}, icon: Image.asset("lib/image/icon_arrow.png"))
                )
              ]
          ),
          ])
      ),
    );
  }
}
