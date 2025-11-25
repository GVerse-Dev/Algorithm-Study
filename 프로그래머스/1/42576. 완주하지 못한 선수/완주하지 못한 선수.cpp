#include <string>
#include <vector>
#include <iostream>
#include <map>
#include <unordered_map>
using namespace std;

string solution(vector<string> participant, vector<string> completion) {
	string answer = "";

	unordered_map<string, int> hashMap;


	for(int i =0 ; i< completion.size(); ++i){

		if(hashMap.find(completion[i]) == hashMap.end()){
			hashMap.insert(make_pair(completion[i], 1));
		}
		else {
			hashMap[completion[i]]++;
		}
	}

	for (int i = 0; i < participant.size(); ++i) {
		if (hashMap.find(participant[i]) == hashMap.end())
			return participant[i];
		else {
			if (--hashMap[participant[i]] <= 0) {
				hashMap.erase(participant[i]);
			}
		}
	}
}