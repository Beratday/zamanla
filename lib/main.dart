import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'providers/randevu_provider.dart';
import 'screens/home_screen.dart';

void main() {
  runApp(const ZamanlaApp());
}

class ZamanlaApp extends StatelessWidget {
  const ZamanlaApp({super.key});

  @override
  Widget build(BuildContext context) {
    return ChangeNotifierProvider(
      create: (_) => RandevuProvider(),
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        title: 'Zamanla',
        theme: ThemeData(
          primarySwatch: Colors.teal,
          useMaterial3: true,
        ),
        home: const HomeScreen(),
      ),
    );
  }
}
