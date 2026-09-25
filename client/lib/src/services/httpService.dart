import 'dart:convert';

import 'package:http/http.dart' as http;

Future<List> getTags() async
{
  try
  {
    var url = Uri.http("localhost:5071", "/api/Tag");

    var response = await http.get(url);

    final body = json.decode(response.body);

    return body;
  }
  catch(e)
  {
    print(e);
    return [];
  }
}