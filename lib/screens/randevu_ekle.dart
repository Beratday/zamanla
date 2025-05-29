import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../providers/randevu_provider.dart';
import '../models/randevu.dart';

class RandevuEkle extends StatefulWidget {
  const RandevuEkle({super.key});

  @override
  State<RandevuEkle> createState() => _RandevuEkleState();
}

class _RandevuEkleState extends State<RandevuEkle> {
  final _formKey = GlobalKey<FormState>();
  final _baslikController = TextEditingController();
  final _aciklamaController = TextEditingController();
  DateTime? _secilenTarih;

  void _tarihSec() async {
    final secilen = await showDatePicker(
      context: context,
      initialDate: DateTime.now(),
      firstDate: DateTime(2023),
      lastDate: DateTime(2100),
    );
    if (secilen != null) {
      final saat = await showTimePicker(
        context: context,
        initialTime: const TimeOfDay(hour: 10, minute: 0),
      );
      if (saat != null) {
        setState(() {
          _secilenTarih = DateTime(
              secilen.year, secilen.month, secilen.day, saat.hour, saat.minute);
        });
      }
    }
  }

  void _kaydet() {
    if (_formKey.currentState!.validate() && _secilenTarih != null) {
      final yeniRandevu = Randevu(
        baslik: _baslikController.text,
        aciklama: _aciklamaController.text,
        tarih: _secilenTarih!,
      );
      Provider.of<RandevuProvider>(context, listen: false)
          .randevuEkle(yeniRandevu);
      Navigator.of(context).pop();
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Randevu Ekle")),
      body: Padding(
        padding: const EdgeInsets.all(16),
        child: Form(
          key: _formKey,
          child: Column(
            children: [
              TextFormField(
                controller: _baslikController,
                decoration: const InputDecoration(labelText: 'Baþlýk'),
                validator: (value) =>
                    value!.isEmpty ? 'Baþlýk giriniz' : null,
              ),
              TextFormField(
                controller: _aciklamaController,
                decoration: const InputDecoration(labelText: 'Açýklama'),
              ),
              const SizedBox(height: 16),
              Row(
                children: [
                  Expanded(
                    child: Text(
                      _secilenTarih == null
                          ? 'Tarih seçilmedi'
                          : _secilenTarih.toString(),
                    ),
                  ),
                  TextButton(
                    onPressed: _tarihSec,
                    child: const Text("Tarih Seç"),
                  ),
                ],
              ),
              const SizedBox(height: 20),
              ElevatedButton(
                onPressed: _kaydet,
                child: const Text("Kaydet"),
              )
            ],
          ),
        ),
      ),
    );
  }
}
