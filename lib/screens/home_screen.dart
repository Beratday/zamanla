import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../providers/randevu_provider.dart';
import 'randevu_ekle.dart';
import '../models/randevu.dart';
import 'package:intl/intl.dart';

class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    final randevuProvider = Provider.of<RandevuProvider>(context);

    return Scaffold(
      appBar: AppBar(
        title: const Text('Zamanla'),
      ),
      body: FutureBuilder(
        future: randevuProvider.yukleRandevular(),
        builder: (ctx, snapshot) {
          final randevular = randevuProvider.randevular;

          if (randevular.isEmpty) {
            return const Center(
              child: Text('Henüz randevu eklenmedi.'),
            );
          }

          return ListView.builder(
            itemCount: randevular.length,
            itemBuilder: (ctx, i) {
              final r = randevular[i];
              return Card(
                margin: const EdgeInsets.symmetric(horizontal: 12, vertical: 6),
                child: ListTile(
                  title: Text(r.baslik),
                  subtitle: Text(
                    '${DateFormat.yMd().add_Hm().format(r.tarih)}\n${r.aciklama}',
                    style: const TextStyle(fontSize: 13),
                  ),
                  isThreeLine: true,
                  trailing: IconButton(
                    icon: const Icon(Icons.delete, color: Colors.red),
                    onPressed: () {
                      randevuProvider.randevuSil(r.id!);
                    },
                  ),
                ),
              );
            },
          );
        },
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.of(context)
              .push(MaterialPageRoute(builder: (_) => const RandevuEkle()));
        },
        child: const Icon(Icons.add),
      ),
    );
  }
}
